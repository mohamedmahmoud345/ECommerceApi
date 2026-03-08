namespace Application.Interfaces.Services.GenerateToken
{
    public interface IGenerateJwtToken
    {
        string GenerateToken(TokenRequestDto tokenRequest);
        (string Token, DateTime ExpiresOnUtc) GenerateRefreshToken();
    }
}
