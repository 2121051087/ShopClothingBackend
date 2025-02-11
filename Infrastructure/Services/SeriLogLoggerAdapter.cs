
using Microsoft.Extensions.Logging;
using ShopClothing.Application.Services.Interfaces.Logging;

namespace ShopClothing.Infrastructure.Services
{
    public class SeriLogLoggerAdapter<T>(ILogger<T> logger) : IAppLogger<T>
    {
        public void LogInformation(string message) => logger.LogInformation(message);
        public void LogWarning(string message) => logger.LogWarning(message);
        public void LogError(Exception ex, string message) => logger.LogError(ex, message);
    }
   
}
