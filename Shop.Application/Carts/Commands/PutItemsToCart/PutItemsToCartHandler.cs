using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Models;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Carts.Commands.PutItemsToCart
{
    public class PutItemsToCartHandler : IRequestHandler<PutItemsToCart>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public PutItemsToCartHandler(ICustomerRepository customerRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(PutItemsToCart request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetAsync(request.CartId);
            if(cart == null)
            {
                throw new ServiceException("cart_not_found", $"Cart with Id {request.CartId} was not found.");
            }

            if(request.UserId != Guid.Empty)
            {
                var customer = await _customerRepository.GetAsync(request.UserId);
                if(customer.UserId != cart.CustomerId)
                {
                    throw new ServiceException("cart_not_owned", "You do not own this cart.");
                }
            }

            foreach (var productItem in request.Products)
            {
                var product = await _productRepository.GetAsync(productItem.ProductId);

                if (product == null)
                {
                    throw new ServiceException("product_not_found", $"Product with Id {productItem.ProductId} was not found.");
                }

                var item = new ProductItem(product, productItem.Quantity);
                cart.AddProductItem(item);
            }

            await _cartRepository.Save();

            return Unit.Value;
        }
    }
}
