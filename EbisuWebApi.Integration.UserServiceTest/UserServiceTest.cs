using EbisuWebApi.Infrastructure.DataModel;
using EbisuWebApi.Infrastructure.IntegrationTests.TestTools;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace EbisuWebApi.Integration.UserServiceTest
{
    public class UserServiceTest : IClassFixture<TestingWebAppFactory<Program>> 
    {
        private readonly HttpClient _client;
        private readonly string _token;
        public UserServiceTest(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _token = TokenFixtures.GetToken();
        }
           

        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            // TODO: move to another method
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_token);

            var response = await _client.GetAsync("/api/v1.0/Users");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseString);
            Assert.True(responseString.Length > 0);
        }
    }
}