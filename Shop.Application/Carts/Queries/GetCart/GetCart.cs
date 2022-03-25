using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Queries.GetCart
{
    public class GetCart : IRequest<CartDto>
    {
        public Guid CartId { get; set; }
    }
}
