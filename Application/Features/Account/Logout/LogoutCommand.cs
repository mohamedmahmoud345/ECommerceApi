using MediatR;

namespace Application.Features.Account.Logout
{
    public class LogoutCommand : IRequest
    {
        public required string RefreshToken { get; set; }
    }
}
