using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Api.Dto.Account;
using Xunit.Abstractions;

namespace IntegrationTests.ControllerTests
{
    public class AccountControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public AccountControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
        {
            _client = factory.CreateClient();
            _output = output;
        }

        [Fact]
        public async Task Register_WithValidData_Return201StatusCode()
        {
            // Given
            var request =
                    new RegisterDto("asdf", "alkjasd42@gmail.com", "SecurePass123!", "01201834567", "beni-suef");

            // When
            var response = await _client.PostAsJsonAsync("/api/account/register", request);

            // Then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task Register_WithDuplicateEmail_Return400BadRequest()
        {
            // Given
            var request =
                        new RegisterDto("ahmed", "ahmed42@gmail.com", "SecurePass123!", "01201834567", "beni-suef");

            // When
            var response = await _client.PostAsJsonAsync("/api/account/register", request);
            var response2 = await _client.PostAsJsonAsync("/api/account/register", request);

            // Debug output
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseBody2 = await response2.Content.ReadAsStringAsync();

            // Then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode); // First should succeed
            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode); // Second should fail
        }
    }
}
