using System;
using MediatR;

namespace Application.Features.Account.Register
{
    public class RegisterCommand : IRequest<AuthResponse>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
    }
}
