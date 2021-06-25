using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Commands.PutItemsToCart
{
    public class PutItemsToCart : IRequest
    {
        public Guid UserId { get; set; }
        public Guid CartId { get; set; }
        public List<ProductItemDto> Products { get; set; }
    }
}
