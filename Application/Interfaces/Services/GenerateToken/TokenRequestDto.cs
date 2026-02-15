namespace Application.Interfaces.Services.GenerateToken
{
    public record class TokenRequestDto
    (Guid UserId, string Email, string Username, IList<string> Roles);
}
