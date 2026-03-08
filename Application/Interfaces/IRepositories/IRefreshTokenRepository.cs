namespace Application.Interfaces.IRepositories
{
    public record RefreshTokenResult(Guid UserId, bool IsExpired, bool IsRevoked);

    public interface IRefreshTokenRepository
    {
        Task AddAsync(Guid userId, string token, DateTime expiresOnUtc);
        Task<RefreshTokenResult?> GetByTokenAsync(string token);
        Task RevokeAsync(string token);
    }
}
