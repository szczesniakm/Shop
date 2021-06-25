using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Commands.CreateCart
{
    public class CreateCart : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public List<ProductItemDto> Products { get; set; }
    }
}
