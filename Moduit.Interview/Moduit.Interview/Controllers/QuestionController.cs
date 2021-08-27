using Microsoft.AspNetCore.Mvc;
using Moduit.Interview.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moduit.Interview.Services;

namespace Moduit.Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly string BASE_URI = "https://screening.moduit.id";
        private readonly IHttpClientService _httpClientService;

        public QuestionController(IServiceProvider serviceProvider)
        {
            _httpClientService = serviceProvider.GetService<IHttpClientService>();
        }

        [HttpGet]
        [Route("one")]
        public async Task<ActionResult> GetQuestionOne()
        {
            try
            {
                var response = await _httpClientService.GetAsync($"{BASE_URI}/backend/question/one");
                response.EnsureSuccessStatusCode();
                string responeData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<QuestionOneModel>(responeData);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("two")]
        public async Task<ActionResult> GetQuestionTwo()
        {
            try
            {
                var data = new List<QuestionTwoModel>();
                var response = await _httpClientService.GetAsync($"{BASE_URI}/backend/question/two");
                response.EnsureSuccessStatusCode();
                string responeData = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<QuestionTwoModel>>(responeData);

                if (data == null)
                    throw new Exception("Data not found");

                //If the description or title contain Ergonomics, there's no result
                //I've asked for it but no result
                var result = data.Where(x =>
                (x.Description.Contains("Ergonomic") || x.Title.Contains("Ergonomic"))
                    && x.Tags != null
                    && x.Tags.Contains("Sports"))
                    .OrderByDescending(x => x.Id)
                    .TakeLast(3);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("three")]
        public async Task<ActionResult> GetQuestionThree()
        {
            try
            {
                var data = new List<QuestionThreeVM>();
                var response = await _httpClientService.GetAsync($"{BASE_URI}/backend/question/three");
                response.EnsureSuccessStatusCode();
                string responeData = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<QuestionThreeVM>>(responeData);

                if (data == null)
                    throw new Exception("Data not found");

                var result = new List<QuestionThreeModel>();
                foreach (var element in data)
                {
                    if (element.Items != null && element.Id != 0 && element.Category != null)
                    {
                        foreach (var item in element.Items)
                        {
                            result.Add(new QuestionThreeModel()
                            {
                                Id = element.Id,
                                Category = element.Category,
                                Title = item.Title,
                                Description = item.Description,
                                Footer = item.Footer,
                                CreatedAt = element.CreatedAt
                            });
                        }
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
