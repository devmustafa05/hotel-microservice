using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Infrastructure.Elastic.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogService
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex = null);
        void LogCritical(string message, Exception ex = null);
        void LogDebug(string message);
    }
}
