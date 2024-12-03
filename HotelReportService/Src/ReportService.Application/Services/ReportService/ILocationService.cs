using ReportService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.ReportService
{
    public interface ILocationService
    {
        Task<List<LocationDto>> GetLocation();
    }
}
