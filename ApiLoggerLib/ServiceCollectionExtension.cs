using Microsoft.Extensions.Logging;

namespace ApiLoggerLib
{
    public static class ServiceCollectionExtension
    {
        public static void AddApiLoggerLib(this ILoggingBuilder builder, string serverUrl = "https://localhost:5001")
        {
            ApiLoggerConfiguration configuration = new ApiLoggerConfiguration();
            configuration.Url = serverUrl;
            builder.AddProvider(new ApiLoggerProvider(configuration));
        }
    }
}