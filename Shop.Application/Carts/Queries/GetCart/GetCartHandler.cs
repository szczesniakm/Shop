using AutoMapper;
using MediatR;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Queries.GetCart
{
    public class GetCartHandler : IRequestHandler<GetCart, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartHandler(ICartRepository cartRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(GetCart request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetAsync(request.CartId);

            return _mapper.Map<CartDto>(cart);
        }
    }
}
