using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.DTOs.Messaging;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using HotelManager.Domain.Enums;
using MassTransit;
using MassTransit.Mediator;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System.Net;
using System.Text;

namespace HotelManager.Application.Features.LocationReport.CreateReport
{
    public class CreateReportMessageConsumer : IConsumer<CreateReporMessageCommandDto>
    {
        IUnitOfWork unitofWork;
        IMapper mapper;
        
        public CreateReportMessageConsumer(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
            
    }
        public async Task Consume(ConsumeContext<CreateReporMessageCommandDto> context)
        {
            try
            {
                var message = context.Message;
                var deneme = message;

                var contactLocationMappings = await unitofWork.GetReadRepostory<ContactLocationMapping>().GetAllAsync(
                      predicate: x => x.IsActive && !x.IsDeleted
                                 && x.LocationId == message.LocationId);

                var hotels = await unitofWork.GetReadRepostory<Hotel>().GetAllAsync(
                     predicate: x => x.IsActive && !x.IsDeleted,
                      include: q => q
                       .Include(h => h.HotelOfficials)
                       .Include(h => h.ContactLocationMappings)
                       .ThenInclude(h => h.Location)
                       .Include(h => h.HotelContacts));

                mapper.Map<HotelOfficialDto, HotelOfficial>(new List<HotelOfficial>());
                mapper.Map<HotelContactsDto, HotelContact>(new List<HotelContact>());

                var hotelsMap = mapper.Map<GetAllHotelsQueryResponse, Hotel>(hotels);

                // TODO:auto mapper will be done
                foreach (var mapHotel in hotelsMap)
                {
                    var hotel = hotels.FirstOrDefault(x => x.Id == mapHotel.Id);
                    if (hotel != null && hotel.ContactLocationMappings != null)
                    {
                        mapHotel.Locations = new List<LocationDto>();
                        foreach (var contactLocationMapping in hotel.ContactLocationMappings)
                        {
                            mapHotel.Locations.Add(
                                new LocationDto()
                                {
                                    Name = contactLocationMapping.Location.Name,
                                    Latitude = contactLocationMapping.Location.Latitude,
                                    Longitude = contactLocationMapping.Location.Longitude
                                });
                        }
                    }
                }

                var hotelContacts = hotelsMap
                            .Where(hotel => hotel.HotelContacts != null) 
                            .SelectMany(hotel => hotel.HotelContacts); 

                var phoneNumberCount =  hotelContacts.Where(x => x.HotelContactType == HotelContactType.PhoneNumber).Count();

                string endpoint = "/api/LocationReport/ResultLocationReport";
                ReportResultDto reportResult = new ReportResultDto()
                {
                    Hotels = hotelsMap.ToList(),
                    ReportDocumentId = message.ReportDocumentId,
                    HotelCount = hotelsMap.ToList().Count(),
                    PhoneCount = phoneNumberCount
                };

                var serializedPayload = JsonConvert.SerializeObject(reportResult);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint)
                {
                    Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json")
                };

                HttpClient httpClient = new HttpClient();
                string baseAddress = "http://localhost:8001";
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer your_token");

                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

                if (response.StatusCode == HttpStatusCode.OK && response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    Log.Error($"CreateReportMessageConsumer /api/LocationReport/ResultLocationReport : {responseMessage}");
                }
            }
            catch (Exception exception)
            {
                Log.Error("This is a CreateReportMessageConsumer HTTP Request: Exception: {ExceptionMessage}, InnerException: {InnerException}, StackTrace: {StackTrace}",
                  exception.Message,
                  exception.InnerException,
                  exception.StackTrace);
                throw;
            }
        }

        public class ReportResultDto
        {
            public int HotelCount { get; set; }
            public int PhoneCount { get; set; }
            public required string ReportDocumentId { get; set; }
            public required List<GetAllHotelsQueryResponse> Hotels { get; set; }
        }
    }
}
