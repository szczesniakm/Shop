using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Carts.Commands.CreateCart;
using Shop.Application.Carts.Commands.DeleteCart;
using Shop.Application.Carts.Commands.PutItemsToCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : BaseController
    {
        public CartsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CreateCart request)
        {
            request.UserId = UserId;

            var cartId = await Mediator.Send(request);

            return Ok(cartId);
        }

        [HttpPut("{cartId}")]
        public async Task<IActionResult> UpdateCart([FromBody] PutItemsToCart request, Guid cartId)
        {
            request.UserId = UserId;
            request.CartId = cartId;

            await Mediator.Send(request);

            return Ok();
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCart(Guid cartId)
        {
            var request = new DeleteCart
            {
                CartId = cartId,
                UserId = UserId
            };

            await Mediator.Send(request);

            return Ok();
        }
    }
}
