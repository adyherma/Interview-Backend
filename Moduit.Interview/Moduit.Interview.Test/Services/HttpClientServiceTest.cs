using Moduit.Interview.Models;
using Moduit.Interview.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Moduit.Interview.Test.Services
{
    public class HttpClientServiceTest : IHttpClientService
    {
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return Task.Run(() => new HttpResponseMessage());
        }
    }

    public class HttpClientServiceQuestionTwoTest : IHttpClientService
    {
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            var rnd = new Random();
            var guid = Guid.NewGuid().ToString("N").Substring(0, 10);
            var listData = new List<QuestionTwoModel>();
            List<string> tags = new List<string>(new string[] { $"Ergonomic {guid}"});
            var model = new QuestionTwoModel()
            {
                Id = rnd.Next(1000, 4000),
                CreatedAt = DateTime.Now,
                Description = "Ergonomic " + guid,
                Footer = guid,
                Title = guid,
                Tags = tags
            };

            listData.Add(model);

            var jsonStringData = JsonConvert.SerializeObject(listData);
            var responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent(jsonStringData);

            return Task.Run(() => responseMessage);
        }
    }

    public class HttpClientServiceQuestionThreeTest : IHttpClientService
    {
        public Task<HttpResponseMessage> GetAsync(string url)
        {            
            var rnd = new Random();
            var guid = Guid.NewGuid().ToString("N").Substring(0, 10);
            var items = new List<BaseModel>();
            var listData = new List<QuestionThreeVM>();

            items.Add(new BaseModel()
            {
                Id = rnd.Next(1000, 4000),
                CreatedAt = DateTime.Now,
                Description = guid,
                Footer = guid,
                Title = guid,
            });

            var model = new QuestionThreeVM()
            {
                Id = rnd.Next(1000, 4000),
                Category = guid,
                CreatedAt = DateTime.Now,
                Description = guid,
                Footer = guid,
                Title = guid,
                Items = items
            };

            listData.Add(model);

            var jsonStringData = JsonConvert.SerializeObject(listData);
            var responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent(jsonStringData);

            return Task.Run(() => responseMessage);
        }
    }
}
