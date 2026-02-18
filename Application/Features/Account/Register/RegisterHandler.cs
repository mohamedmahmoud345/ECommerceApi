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
        public RegisterHandler(IUnitOfWork unitOfWork, IGenerateJwtToken jwtToken, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _jwtToken = jwtToken;
            _authService = authService;
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

            var token = _jwtToken.GenerateToken(tokenRequest);

            return new AuthResponse()
            {
                Token = token,
                Email = request.Email,
                Name = request.Name
            };
        }
    }
}
