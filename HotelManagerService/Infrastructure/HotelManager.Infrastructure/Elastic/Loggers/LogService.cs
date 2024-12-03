using Microsoft.Extensions.Logging;

namespace HotelManager.Infrastructure.Elastic.Loggers
{
    public class LogService : ILogService
    {
        private readonly ILogger<LogService> logger;

        public LogService(ILogger<LogService> logger)
        {
            this.logger = logger;
        }

        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            logger.LogWarning(message);
        }

        public void LogError(string message, Exception ex = null)
        {
            if (ex != null)
            {
                logger.LogError(ex, message);
            }
            else
            {
                logger.LogError(message);
            }
        }

        public void LogCritical(string message, Exception ex = null)
        {
            if (ex != null)
            {
                logger.LogCritical(ex, message);
            }
            else
            {
                logger.LogCritical(message);
            }
        }

        public void LogDebug(string message)
        {
            logger.LogDebug(message);
        }
    }
}
