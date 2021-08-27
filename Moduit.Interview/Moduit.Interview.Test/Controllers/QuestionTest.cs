using Moduit.Interview.Controllers;
using Moduit.Interview.Models;
using Moduit.Interview.Services;
using Moduit.Interview.Test.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Moduit.Interview.Test.Controllers
{
    public class QuestionTest
    {
        [Fact]
        public async Task Should_Success_GetQuestionOne()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(IHttpClientService)))
                .Returns(new HttpClientServiceTest());

            var service = new QuestionController(serviceProvider.Object);
            var result = await service.GetQuestionOne();
            Assert.Equal((int)HttpStatusCode.OK, result.GetType().GetProperty("StatusCode").GetValue(result, null));
        }

        [Fact]
        public async Task Should_Success_GetQuestionTwo()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(IHttpClientService)))
                .Returns(new HttpClientServiceQuestionTwoTest());
            var service = new QuestionController(serviceProvider.Object);
            var result = await service.GetQuestionTwo();
            Assert.Equal((int)HttpStatusCode.OK, result.GetType().GetProperty("StatusCode").GetValue(result, null));
        }

        [Fact]
        public async Task Should_Success_GetQuestionThree()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(IHttpClientService)))
                .Returns(new HttpClientServiceQuestionThreeTest());

            var service = new QuestionController(serviceProvider.Object);
            var result = await service.GetQuestionThree();
            Assert.Equal((int)HttpStatusCode.OK, result.GetType().GetProperty("StatusCode").GetValue(result, null));
        }

        [Fact]
        public async Task Should_Failed_GetQuestionTwo()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(IHttpClientService)))
                .Returns(new HttpClientServiceTest());

            var service = new QuestionController(serviceProvider.Object);
            Exception message = await Assert.ThrowsAnyAsync<Exception>(() => service.GetQuestionTwo());
            Assert.Equal("Data not found", message.Message);
        }


        [Fact]
        public async Task Should_Failed_GetQuestionThree()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(IHttpClientService)))
                .Returns(new HttpClientServiceTest());

            var service = new QuestionController(serviceProvider.Object);
            Exception message = await Assert.ThrowsAnyAsync<Exception>(() => service.GetQuestionThree());
            Assert.Equal("Data not found", message.Message);
        }
    }
}
