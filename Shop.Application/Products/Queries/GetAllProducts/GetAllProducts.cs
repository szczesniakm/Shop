using MediatR;
using Shop.Application.Products.Queries.GetProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Queries.GetAllProducts
{
    public class GetAllProducts : IRequest<IEnumerable<ProductDto>>
    {
    }
}
