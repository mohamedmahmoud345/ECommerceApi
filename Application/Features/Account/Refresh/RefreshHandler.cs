using Application.Interfaces.IRepositories;
using Application.Interfaces.Services;
using Application.Interfaces.Services.GenerateToken;
using MediatR;

namespace Application.Features.Account.Refresh
{
    public class RefreshHandler : IRequestHandler<RefreshCommand, RefreshResponse?>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IAuthService _authService;
        private readonly IGenerateJwtToken _jwtToken;

        public RefreshHandler(
            IRefreshTokenRepository refreshTokenRepository,
            IAuthService authService,
            IGenerateJwtToken jwtToken)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _authService = authService;
            _jwtToken = jwtToken;
        }

        public async Task<RefreshResponse?> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            var tokenResult = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

            if (tokenResult is null || tokenResult.IsExpired || tokenResult.IsRevoked)
                return null;

            var userInfo = await _authService.GetUserInfoAsync(tokenResult.UserId);
            if (!userInfo.Found)
                return null;

            var roles = await _authService.GetUserRolesAsync(tokenResult.UserId);

            var tokenRequest = new TokenRequestDto(
                tokenResult.UserId,
                userInfo.Email,
                userInfo.UserName,
                roles);

            var newAccessToken = _jwtToken.GenerateToken(tokenRequest);

            return new RefreshResponse { AccessToken = newAccessToken };
        }
    }
}
