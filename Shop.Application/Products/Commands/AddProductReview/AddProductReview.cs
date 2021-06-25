using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands
{
    public class AddProductReview : IRequest
    {
        public string Slug { get; set; }
        public Guid UserId { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
