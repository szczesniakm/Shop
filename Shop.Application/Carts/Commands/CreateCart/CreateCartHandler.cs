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

namespace Shop.Application.Carts.Commands.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCart, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CreateCartHandler(ICustomerRepository customerRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
        }

        async Task<Guid> IRequestHandler<CreateCart, Guid>.Handle(CreateCart request, CancellationToken cancellationToken)
        {
            Customer customer = null;

            if (request.UserId != Guid.Empty)
            {
                customer = await _customerRepository.GetAsync(request.UserId);
            }

            var cart = new Cart();
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


            if (customer != null)
                customer.AddCart(cart);

            await _cartRepository.AddAsync(cart);
            await _cartRepository.Save();

            return cart.Id;
        }
    }
}
