using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Moduit.Interview.Services
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient _client = new HttpClient();
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
    }

    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
