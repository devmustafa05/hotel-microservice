﻿using Microsoft.AspNetCore.Mvc;
using ReportService.Application.DTOs;
using ReportService.Application.DTOs.ResultLocationReport;
using ReportService.Application.ExternalServices;
using ReportService.Application.Services.ReportService;
using System.ComponentModel;

namespace ReportService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocationReportController : ControllerBase
    {
        private readonly IReportService reportService;
        private readonly ILocationService locationService;
        public LocationReportController(IReportService reportService,
            ILocationService locationService,
            IExternalApiService externalApiService)
        {
            this.reportService = reportService;
            this.locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var response = await reportService.GetReports();
            return Ok(response);
        }


        [HttpGet("/locations")]
        public async Task<IActionResult> GetLocations()
        {
            var response = await locationService.GetLocation();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreteLocationReport(CreteLocationRequestDto request)
        {
            var response = await reportService.CreteLocationReport(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ResultLocationReport(ResultLocationReportDto request)
        {
            var response = await reportService.UpdateLocationReportDetail(request);
            return Ok(response);
        }
       
    }
}
