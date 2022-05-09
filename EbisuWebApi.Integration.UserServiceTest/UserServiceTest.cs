using EbisuWebApi.Infrastructure.DataModel;
using EbisuWebApi.Infrastructure.IntegrationTests.TestTools;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        [Fact]
        public async Task AddUser()
        {
            var userDatamodel =  new UserDataModel
            {
                UserId = 1,
                UserName = "paco",
                Email = "paco@gmail.com",
                Password = "123"
            };

            var content = JsonConvert.SerializeObject(userDatamodel);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // TODO: move to another method
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.PostAsync("/api/v1.0/Users", byteContent);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseString);
            Assert.True(responseString.Length > 0);
        }
    }
}