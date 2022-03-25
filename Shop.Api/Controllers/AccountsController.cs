using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Commands.ChangePassword;
using Shop.Application.Users.Commands.Login;
using Shop.Application.Users.Commands.RegisterUser;
using Shop.Application.Users.Commands.RequestPasswordReset;
using Shop.Application.Users.Commands.ResetPassword;
using Shop.Application.Users.Commands.VerifyEmail;
using System;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : BaseController
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser request)
        {
            await Mediator.Send(request);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmail request)
        {
            var token = await Mediator.Send(request);
            return NoContent();
        }

        [Authorize]
        [HttpPut("me/password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword request)
        {
            request.Id = UserId;
            var token = await Mediator.Send(request);
            return NoContent();
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword request)
        {
            var token = await Mediator.Send(request);
            return NoContent();
        }

        [HttpPut("password")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordReset request, Guid id)
        {
            var token = await Mediator.Send(request);
            return NoContent();
        }
    }
}
