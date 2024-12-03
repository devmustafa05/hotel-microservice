using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using ReportService.Application.DTOs;
using ReportService.Application.DTOs.ResultLocationReport;
using ReportService.Application.ExternalServices;
using ReportService.Domain.DocumentProperties.ReportDocuments;
using ReportService.Domain.Documents;
using ReportService.Domain.Enums;
using ReportService.Persistence.Repositories;

namespace ReportService.Application.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IRepository<ReportDocuments> hotelRepository;
        private readonly IExternalApiService externalApiService;
        private readonly IConfiguration configuration;

        public ReportService(IRepository<ReportDocuments> hotelRepository, IExternalApiService externalApiService, IConfiguration configuration)
        {
            this.hotelRepository = hotelRepository;
            this.externalApiService = externalApiService;
            this.configuration = configuration;
        }

        public async Task<bool> CreteLocationReport(CreteLocationRequestDto creteLocationRequest)
        {   
            ReportDocuments reportDocument = new ReportDocuments()
            {
                Name = "Lokasyon Raporu",
                ReportDocumentStatuType = ReportDocumentStatuType.Sent,
                ReportRequestParameter = new ReportRequestParameter()
                {
                   // Id  = ObjectId.GenerateNewId(),
                    LocationId = creteLocationRequest.LocationId,
                    Latitude = creteLocationRequest.Latitude,
                    longitude = creteLocationRequest.Longitude
                }
            };

            var reportDocumentAdded = await hotelRepository.CreateAsync(reportDocument);

            if(reportDocumentAdded == null)
            {
                // bir hata fırlatılabilir 
                throw new Exception();
            }

            CreteLocationReportPostDto creteLocationReportPost = new CreteLocationReportPostDto();
            creteLocationReportPost.LocationId = creteLocationRequest.LocationId;
            creteLocationReportPost.ReportDocumentId = reportDocumentAdded.Id;
            creteLocationReportPost.Longitude = creteLocationRequest.Longitude;
            creteLocationReportPost.Latitude = creteLocationRequest.Latitude;

            var createResult = await CreteLocationRequest(creteLocationReportPost);

            if (!createResult)
            {
                // bir hata fırlatılabilir 
                throw new Exception();
            }

            reportDocumentAdded.ReportDocumentStatuType = ReportDocumentStatuType.Reporting;
            var result = await hotelRepository.UpdateAsync(reportDocumentAdded.Id, reportDocumentAdded);
            return result;
        }
        public async Task<bool> CreteLocationRequest(CreteLocationReportPostDto request)
        {
            var endPoint = configuration["HotelMicroServis:GetReport"];
            endPoint = string.IsNullOrWhiteSpace(endPoint) ? "/api/Report/GetReport" : endPoint;
            var response = await externalApiService.PostDataAsync<CreteLocationReportPostDto>(endPoint, request);
            return response;
        }

        public async Task<List<ReportDocuments>> GetReports()
        {
            // auery eklenecekcek
            var reportDocuments = await hotelRepository.GetAllAsync();
            return reportDocuments.ToList();
           // throw new NotImplementedException(); ;
        }

        public async Task<bool> UpdateLocationReportDetail(ResultLocationReportDto updatedLocationReport)
        {  
            ObjectId reportDocumentId = ObjectId.Parse(updatedLocationReport.ReportDocumentId);
            var reportDocument = await hotelRepository.GetByIdAsync(reportDocumentId);

            if(reportDocument == null)
            {   
                // bir hata fırlatılabilir 
                throw new Exception();
            }

            var reportDocumensHotels = updatedLocationReport.Hotels.Select(s => new ReportDocumensHotel()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                LocationName = s.LocationName,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                HotelOfficials = s.HotelOfficials.Select(os => new ReportDocumensHotelOfficial()
                {
                    Id = os.Id,
                    Name = os.Name,
                    SurName = os.SurName,
                    CorporateTitle = os.CorporateTitle
                }).ToList(),

                HotelContacts = s.HotelContacts.Select(cs => new ReportDocumensHotelContact()
                {
                    Id = cs.Id,
                    HotelContactType = cs.HotelContactType,
                    // HotelContactType = HotelContactType.PhoneNumber,
                    Content = cs.Content
                }).ToList(),

                HotelLocationContacts = s.HotelLocationContacts.Select(ls => new ReportDocumensHotelLocationContact()
                {
                    Id = ls.Id,
                    Name = ls.Name,
                    Latitude = ls.Latitude,
                    Longitude = ls.Longitude
                }).ToList()
            }).ToList();

            reportDocument.ReportDocumentStatuType = ReportDocumentStatuType.ReportReady;
            reportDocument.HotelCount = updatedLocationReport.HotelCount;
            reportDocument.PhoneCount = updatedLocationReport.PhoneCount;
            reportDocument.ReportHotels = reportDocumensHotels;
            await hotelRepository.UpdateAsync(reportDocumentId, reportDocument);


            throw new NotImplementedException();
        }
    }
}
