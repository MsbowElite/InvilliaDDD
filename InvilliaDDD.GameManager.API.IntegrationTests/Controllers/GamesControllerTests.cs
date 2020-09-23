using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace InvilliaDDD.GameManager.API.IntegrationTests.Controllers
{
    public class GamesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GamesControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetAll_WithoutAuthorization()
        {
            var response = await _client.GetAsync("/api/games");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
