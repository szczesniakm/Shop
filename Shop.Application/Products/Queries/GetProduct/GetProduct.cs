using MediatR;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Queries
{
    public class GetProduct : IRequest<Product>
    {
        public string Slug { get; set; }
    }
}
