using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] CreateOrder request)
        {
            request.UserId = UserId;

            await Mediator.Send(request);
            return NoContent();
        }
    }
}
