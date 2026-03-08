using Api.Dto.Account;
using Application.Features.Account.Login;
using Application.Features.Account.Logout;
using Application.Features.Account.Refresh;
using Application.Features.Account.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
            var registerCommand = new RegisterCommand()
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password,
                Phone = registerDto.Phone,
                Address = registerDto.Address
            };

            var result = await _mediator.Send(registerCommand);
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

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshDto refreshDto)
        {
            var result = await _mediator.Send(new RefreshCommand
            {
                RefreshToken = refreshDto.RefreshToken
            });

            if (result is null)
                return Unauthorized();

            return Ok(result);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutDto logoutDto)
        {
            await _mediator.Send(new LogoutCommand
            {
                RefreshToken = logoutDto.RefreshToken
            });

            return NoContent();
        }
    }
}
