using MediatR;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Queries.GetProduct
{
    public class GetProduct : IRequest<ProductDto>
    {
        public string Slug { get; set; }
    }
}
