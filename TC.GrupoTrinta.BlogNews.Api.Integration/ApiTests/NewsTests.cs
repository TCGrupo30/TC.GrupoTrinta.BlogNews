using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.CreateNews;

namespace TC.GrupoTrinta.BlogNews.Api.Integration.ApiTests
{
    public class NewsTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _testFixtureBase;

        public NewsTests(
               WebApplicationFactory<Program> testFixtureBase
        )
        {
            _testFixtureBase = testFixtureBase;                     
        }

        [Fact]
        public async Task CreateNews_WorkAsExpected()
        {
            var payload = new CreateNewsInput()
            {
                Title = "Title",
                Description = "Description",
                Author = "Author",
                PublicationDate = DateTime.Now.AddDays(-1)
            };
            var payloadJson = JsonConvert.SerializeObject(payload);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "News");
            requestMessage.Content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
            var client = _testFixtureBase.CreateDefaultClient();
            var response = await client.SendAsync(requestMessage);

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);
           
        }

        [Fact]
        public async Task GetNews_WorkAsExpected()
        {
            await CreateNews_WorkAsExpected();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "News/GetAll");
            var client = _testFixtureBase.CreateDefaultClient();

            var response = await client.SendAsync(requestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<NewsModelOutput>>(jsonString);

            Assert.True(result.Count == 1);
        }
    }
}
