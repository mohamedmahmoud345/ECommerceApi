using System.Net;
using System.Net.Http.Json;
using Api.Dto.Account;
using Application.Features.Account;

namespace IntegrationTests.ControllerTests
{
    public class AccountControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        public AccountControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
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
                        new RegisterDto("ahmed", "alkjasd42@gmail.com", "SecurePass123!", "01201834567", "beni-suef");

            // When
            var response = await _client.PostAsJsonAsync("/api/account/register", request);
            var response2 = await _client.PostAsJsonAsync("/api/account/register", request);

            // Then
            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode); // Second should fail
        }
        [Fact]
        public async Task Login_WithInValidPassword_return400BadRequest()
        {
            // Given
            var register = new RegisterDto("ahmed", "try-test1@gmail.com", "SecurePass123!", "01201834567", "beni-suef");
            var request = new LoginDto("try-test1@gmail.com", "SecuePass123!");
            // When
            var response = await _client.PostAsJsonAsync("api/account/register", register);
            var response2 = await _client.PostAsJsonAsync("api/account/login", request);
            // Then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode);
        }
        [Fact]
        public async Task Login_WithInValidEmail_return400BadRequest()
        {
            // Given
            var register = new RegisterDto("abdo", "trytest2@gmail.com", "SecurePass123!", "01201834567", "beni-suef");
            var request = new LoginDto("trdy-test2@gmail.com", "SecurePass123!");
            // When
            var response = await _client.PostAsJsonAsync("api/account/register", register);
            var response2 = await _client.PostAsJsonAsync("api/account/login", request);
            // Then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode);
        }
        [Fact]
        public async Task Login_WithValidData_return200Ok()
        {
            // Given
            var register = new RegisterDto("mohmd", "try-test3@gmail.com", "SecurePass123!", "01201834567", "beni-suef");
            var request = new LoginDto("try-test3@gmail.com", "SecurePass123!");
            // When
            var response = await _client.PostAsJsonAsync("api/account/register", register);
            var response2 = await _client.PostAsJsonAsync("api/account/login", request);
            // Then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);

            var loginResult = await response2.Content.ReadFromJsonAsync<AuthResponse>();
            Assert.NotNull(loginResult);
            Assert.NotNull(loginResult.Token);
            Assert.NotEmpty(loginResult.Token);
        }
    }
}
