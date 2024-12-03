using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.DTOs.Messaging;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using HotelManager.Domain.Enums;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

                var contactLocationMapping = await unitofWork.GetReadRepostory<ContactLocationMapping>().GetAllAsync(
                        predicate: x => x.IsActive && !x.IsDeleted
                                   && x.LocationId == message.LocationId);

                var hotelLocationContactIds = contactLocationMapping.Select(s => s.HotelLocationContactId).ToList();

                var hotelLocationContacts = await unitofWork.GetReadRepostory<HotelLocationContact>()
                                                    .GetAllAsync(predicate: x => x.IsActive && !x.IsDeleted
                                                     && hotelLocationContactIds.Contains(x.Id));


                var hotelIds = hotelLocationContacts.GroupBy(s => s.HotelId).Select(s => s.Key).ToList();

                var hotelContactPhoneNumber = unitofWork.GetReadRepostory<HotelContact>().GetAllAsync(
                        predicate: x => x.IsActive && !x.IsDeleted
                                    && hotelIds.Contains(x.HotelId)
                                    && x.HotelContactType == HotelContactType.PhoneNumber).Result;

                var phoneNumbers = hotelContactPhoneNumber.GroupBy(s => s.Content).Select(s => s.Key).ToList();

                var hotelCount = hotelIds.Count();
                var PhoneNumberCount = phoneNumbers.Count();


                var hotels = await unitofWork.GetReadRepostory<Hotel>().GetAllAsync(
                          predicate: x => x.IsActive && !x.IsDeleted
                                       && hotelIds.Contains(x.Id),
                           include: q => q
                            .Include(h => h.HotelOfficials)
                            .Include(h => h.HotelContacts)
                           .Include(h => h.HotelLocationContacts));

                await unitofWork.GetWriteRepostory<Hotel>().AddARangAsync(hotels);

                mapper.Map<HotelOfficialDto, HotelOfficial>(new List<HotelOfficial>());
                mapper.Map<HotelContactsDto, HotelContact>(new List<HotelContact>());
                mapper.Map<HotelLocationContactDto, HotelLocationContact>(new List<HotelLocationContact>());

                var map = mapper.Map<GetAllHotelsQueryResponse, Hotel>(hotels);
                var mapHotels = map.ToList();


                try
                {
                    string endpoint = "/api/LocationReport/ResultLocationReport";
                    ReportResultDto reportResult = new ReportResultDto()
                    {
                        Hotels = mapHotels,
                        ReportDocumentId = message.ReportDocumentId,
                        HotelCount = hotelCount,
                        PhoneCount = phoneNumbers.Count()
                    };
                    reportResult.HotelCount = hotelCount;
                    reportResult.PhoneCount = phoneNumbers.Count();

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
                    }
                    
                }
                catch (Exception ex)
                {
                    var ssTest = ex;
                }


            }
            catch (Exception exception)
            {
                var ssDeneme = exception;
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
