using AutoMapper;
using MediatR;
using Shop.Application.Products.Queries.GetProduct;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }
    }

}
