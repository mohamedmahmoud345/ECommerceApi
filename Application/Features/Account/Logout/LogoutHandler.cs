using Application.Interfaces.IRepositories;
using MediatR;

namespace Application.Features.Account.Logout
{
    public class LogoutHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LogoutHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _refreshTokenRepository.RevokeAsync(request.RefreshToken);
        }
    }
}
