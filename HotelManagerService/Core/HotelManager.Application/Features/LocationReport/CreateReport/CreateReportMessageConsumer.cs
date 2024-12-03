using HotelManager.Application.DTOs.Messaging;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using HotelManager.Domain.Enums;
using MassTransit;
using Newtonsoft.Json;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.LocationReport.CreateReport
{
    public class CreateReportMessageConsumer : IConsumer<CreateReporMessageCommandDto>
    {
        IUnitOfWork unitofWork;
        public CreateReportMessageConsumer(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
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



                try
                {
                    string endpoint = "/LocationReport/ResultLocationReport";
                    ReportResultDto reportResult = new ReportResultDto();
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
        }
    }
}
