using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiLoggerLib
{
    public class ApiLoggerClient
    {

        private HttpClient _client;
        private string _baseUrl;

        public ApiLoggerClient(ApiLoggerConfiguration configuration)
        {
            _client = new HttpClient();
            _baseUrl = configuration.Url;
        }

        public async Task<HttpResponseMessage> CreateMesssage(Message message)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"{_baseUrl}/message", message);
            return response;
        }
    }
}
