using Application.Interfaces.Services;
using Application.Interfaces.Services.GenerateToken;
using MediatR;

namespace Application.Features.Account.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IGenerateJwtToken _jwtToken;
        private readonly IAuthService _authService;
        public LoginHandler(IGenerateJwtToken jwtToken, IAuthService authService)
        {
            _jwtToken = jwtToken;
            _authService = authService;
        }
        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.LoginAsync(request.Email, request.Password);
            if (!authResult.Success)
                return null;

            var roles = await _authService.GetUserRolesAsync(authResult.UserId);

            var tokenRequest =
                new TokenRequestDto(authResult.UserId, request.Email, authResult.UserName, roles);

            var token = _jwtToken.GenerateToken(tokenRequest);

            return new AuthResponse()
            {
                Token = token,
                Name = authResult.UserName,
                Email = request.Email
            };
        }
    }
}
