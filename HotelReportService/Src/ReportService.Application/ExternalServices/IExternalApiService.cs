using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.ExternalServices
{
    public interface IExternalApiService
    {
        Task<string> GetDataAsync(string endpoint);
        Task<bool> PostDataAsync<T>(string endpoint, T payload);
    }
}
