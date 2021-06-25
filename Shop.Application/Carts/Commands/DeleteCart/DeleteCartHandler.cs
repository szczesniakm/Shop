using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Commands.DeleteCart
{
    public class DeleteCartHandler : IRequestHandler<DeleteCart>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public DeleteCartHandler(ICustomerRepository customerRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(DeleteCart request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetAsync(request.CartId);
            if (cart == null)
            {
                throw new ServiceException("cart_not_found", $"Cart with Id {request.CartId} was not found.");
            }

            if(cart.CustomerId != null)
            {
                var customer = await _customerRepository.GetAsync(request.UserId);
                if (customer == null)
                {
                    throw new ServiceException("cart_not_owned", "You do not own this cart.");
                }
                if (customer.UserId != cart.CustomerId)
                {
                    throw new ServiceException("cart_not_owned", "You do not own this cart.");
                }
            }

            await _cartRepository.RemoveAsync(cart);

            await _cartRepository.Save();

            return Unit.Value;
        }
    }
}
