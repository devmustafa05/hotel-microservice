﻿using ReportService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.ReportService
{
    public interface IReportService
    {   
        Task<bool> CreteLocationReport(CreteLocationRequestDto creteLocationRequest);
        Task<bool> CreteLocationRequest(CreteLocationReportPostDto request);
    }
}