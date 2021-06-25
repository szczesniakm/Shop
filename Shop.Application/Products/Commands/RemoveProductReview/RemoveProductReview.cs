using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.RemoveProductReview
{
    public class RemoveProductReview : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ReviewId { get; set; }
    }
}
