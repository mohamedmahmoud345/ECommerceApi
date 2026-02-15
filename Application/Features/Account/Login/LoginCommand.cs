using System;
using MediatR;

namespace Application.Features.Account.Login
{
    public class LoginCommand : IRequest<AuthResponse>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
