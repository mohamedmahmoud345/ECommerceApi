using Api.Dto.Account;
using Application.Features.Account.Login;
using Application.Features.Account.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var RegisterCommand = new RegisterCommand()
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password,
                Phone = registerDto.Phone,
                Address = registerDto.Address
            };

            var result = await _mediator.Send(RegisterCommand);
            if (result is null)
                return BadRequest();

            return CreatedAtAction(nameof(Register), result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var loginCommand = new LoginCommand()
            {
                Email = loginDto.Email,
                Password = loginDto.Password
            };

            var result = await _mediator.Send(loginCommand);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }
    }
}
