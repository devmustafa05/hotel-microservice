using ReportService.Application.DTOs;
using ReportService.Application.DTOs.ResultLocationReport;
using ReportService.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.ReportService
{
    public interface IReportService
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creteLocationRequest"></param>
        /// <returns></returns>
        Task<bool> CreteLocationReport(CreteLocationRequestDto creteLocationRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> CreteLocationRequest(CreteLocationReportPostDto request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creteLocationRequest"></param>
        /// <returns></returns>
        Task<bool> UpdateLocationReportDetail(ResultLocationReportDto updatedLocationReport);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ReportDocuments>> GetReports();

    }
}
