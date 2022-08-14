using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLoggerLib
{
    public class ApiLogger : ILogger
    {
        ApiLoggerClient _client;
        string? _key;

        public ApiLogger(ApiLoggerClient client, string key)
        {
            _client = client;
            _key = key;    
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return default!;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Task.Run(() => _client.CreateMesssage(new Message
            {
                LogLevel = logLevel,
                Key = _key,
                Title = eventId.Id.ToString(),
                Description = formatter(state, exception) ?? "",
            }));

        }
    }
}
