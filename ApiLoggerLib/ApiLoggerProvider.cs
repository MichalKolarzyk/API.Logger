using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLoggerLib
{
    public class ApiLoggerProvider : ILoggerProvider
    {
        private ApiLoggerClient _client;

        public ApiLoggerProvider(ApiLoggerConfiguration configuration)
        {
            _client = new ApiLoggerClient(configuration);
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ApiLogger(_client, categoryName);
        }

        public void Dispose()
        {
            return;
        }
    }
}
