using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands;
using Shop.Application.Products.Commands.RemoveProductReview;
using Shop.Application.Products.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetProducts(string slug)
        {
            var request = new GetProduct { Slug = slug };

            var product = await Mediator.Send(request);

            return Ok(product);
        }

        [Authorize]
        [HttpPost("{slug}/reviews")]
        public async Task<IActionResult> AddProductReview([FromBody]AddProductReview request, string slug)
        {
            request.UserId = UserId;
            request.Slug = slug;

            await Mediator.Send(request);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{slug}/reviews/{reviewId}")]
        public async Task<IActionResult> RemoveProductReview([FromBody] RemoveProductReview request, Guid reviewId)
        {
            request.UserId = UserId;
            request.ReviewId = reviewId;

            await Mediator.Send(request);

            return Ok();
        }
    }
}
