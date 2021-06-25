using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Models;
using Shop.Domain.Repositories;

namespace Shop.Application.Products.Queries
{
    public class GetProductHandler : IRequestHandler<GetProduct, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        async Task<Product> IRequestHandler<GetProduct, Product>.Handle(GetProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetBySlugAsync(request.Slug);
            return product;
        }
    }
}
