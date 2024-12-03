using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using ReportService.Application.DTOs;
using ReportService.Application.ExternalServices;
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
                ReportRequestParameters = new ReportRequestParameters()
                {
                    Id  = ObjectId.GenerateNewId(),
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

            var result = await CreteLocationRequest(creteLocationReportPost);

            if (!result)
            {
                // bir hata fırlatılabilir 
                throw new Exception();
            }
            return result;
        }
        public async Task<bool> CreteLocationRequest(CreteLocationReportPostDto request)
        {
            var endPoint = configuration["HotelMicroServis:GetReport"];
            endPoint = string.IsNullOrWhiteSpace(endPoint) ? "/api/Report/GetReport" : endPoint;
            var response = await externalApiService.PostDataAsync<CreteLocationReportPostDto>(endPoint, request);
            return response;
        }
    }
}
