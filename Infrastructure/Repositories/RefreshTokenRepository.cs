using Application.Interfaces.IRepositories;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;

        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Guid userId, string token, DateTime expiresOnUtc)
        {
            var refreshToken = new RefreshToken(token, userId, expiresOnUtc);
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshTokenResult?> GetByTokenAsync(string token)
        {
            var rt = await _context.RefreshTokens
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Token == token);

            if (rt is null)
                return null;

            return new RefreshTokenResult(rt.UserId, rt.IsExpired, rt.IsRevoked);
        }

        public async Task RevokeAsync(string token)
        {
            var rt = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == token);

            if (rt is null)
                return;

            rt.Revoke();
            await _context.SaveChangesAsync();
        }
    }
}
