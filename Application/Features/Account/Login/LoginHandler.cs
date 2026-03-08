using Application.Interfaces.IRepositories;
using Application.Interfaces.Services;
using Application.Interfaces.Services.GenerateToken;
using MediatR;

namespace Application.Features.Account.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IGenerateJwtToken _jwtToken;
        private readonly IAuthService _authService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LoginHandler(
            IGenerateJwtToken jwtToken,
            IAuthService authService,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _jwtToken = jwtToken;
            _authService = authService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.LoginAsync(request.Email, request.Password);
            if (!authResult.Success)
                return null;

            var roles = await _authService.GetUserRolesAsync(authResult.UserId);

            var tokenRequest =
                new TokenRequestDto(authResult.UserId, request.Email, authResult.UserName, roles);

            var accessToken = _jwtToken.GenerateToken(tokenRequest);
            var (refreshToken, refreshTokenExpiry) = _jwtToken.GenerateRefreshToken();

            await _refreshTokenRepository.AddAsync(authResult.UserId, refreshToken, refreshTokenExpiry);

            return new AuthResponse()
            {
                Token = accessToken,
                Name = authResult.UserName,
                Email = request.Email,
                RefreshToken = refreshToken,
                RefreshTokenExpiry = refreshTokenExpiry
            };
        }
    }
}
