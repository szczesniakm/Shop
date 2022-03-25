using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Domain.Repositories;

namespace Shop.Application.Products.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProduct, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetBySlugAsync(request.Slug);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
