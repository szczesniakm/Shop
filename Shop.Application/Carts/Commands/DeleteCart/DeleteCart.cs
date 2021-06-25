using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Commands.DeleteCart
{
    public class DeleteCart : IRequest
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
    }
}
