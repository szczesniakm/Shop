using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Customers.Commands.UpdateCustomerDetails;
using Shop.Application.Customers.Queries.GetCustomerDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : BaseController
    {
        public CustomersController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateCustomerDetails([FromBody] UpdateCustomerDetails request)
        {
            request.Id = UserId;
            await Mediator.Send(request);
            return NoContent();
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCustomerDetails([FromBody] GetCustomerDetails request)
        {
            request.Id = UserId;
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
