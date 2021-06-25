using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Commands
{
    public class ProductItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
