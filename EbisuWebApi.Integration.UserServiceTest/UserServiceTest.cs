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
        public UserServiceTest(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            // TODO: move to another method
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJSYWZhIiwiZW1haWwiOiJnYXlvc28wNTk3QGdtYWlsLmNvbSIsIn" +
                "JvbGUiOiJBZG1pbiIsIm5iZiI6MTY1MTg1MjI4OSwiZXhwIjoxNjUyNDU3MDg5LCJpYXQiOjE2NTE4NTIyODl9.PBCg2LhR4_O7171qnSvf0jv3NH8fRBiD0xJbXqogTv4");

            var response = await _client.GetAsync("/api/v1.0/Users");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("", responseString);
           

           
           
        }
    }
}