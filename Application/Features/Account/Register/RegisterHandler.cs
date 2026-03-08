using Application.Interfaces.IRepositories;
using Application.Interfaces.Services;
using Application.Interfaces.Services.GenerateToken;
using Application.IUnitOfWorks;
using Core.Entities;
using MediatR;

namespace Application.Features.Account.Register
{
    public class RegisterHandler :
        IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenerateJwtToken _jwtToken;
        private readonly IAuthService _authService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RegisterHandler(
            IUnitOfWork unitOfWork,
            IGenerateJwtToken jwtToken,
            IAuthService authService,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _unitOfWork = unitOfWork;
            _jwtToken = jwtToken;
            _authService = authService;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var authResult = await _authService
                .RegisterUserAsync(request.Email, request.Name, request.Password);

            if (!authResult.Success)
                return null;

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    var customer =
                        new Customer(request.Name, request.Address, request.Phone, authResult.UserId);

                    await _unitOfWork.Customers.AddAsync(customer);

                    await _unitOfWork.SaveChangesAsync();
                });
            }
            catch
            {
                throw;
            }

            var userRoles = await _authService.GetUserRolesAsync(authResult.UserId);
            var tokenRequest =
                new TokenRequestDto(authResult.UserId, request.Email, request.Name, userRoles);

            var accessToken = _jwtToken.GenerateToken(tokenRequest);
            var (refreshToken, refreshTokenExpiry) = _jwtToken.GenerateRefreshToken();

            await _refreshTokenRepository.AddAsync(authResult.UserId, refreshToken, refreshTokenExpiry);

            return new AuthResponse()
            {
                Token = accessToken,
                Email = request.Email,
                Name = request.Name,
                RefreshToken = refreshToken,
                RefreshTokenExpiry = refreshTokenExpiry
            };
        }
    }
}
