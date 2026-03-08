namespace Application.Features.Account
{
    public class AuthResponse
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string RefreshToken { get; set; }
        public required DateTime RefreshTokenExpiry { get; set; }
    }
}
