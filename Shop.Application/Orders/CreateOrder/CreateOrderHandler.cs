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

namespace Shop.Application.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(ICustomerRepository customerRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.UserId);
            var cart = await _cartRepository.GetAsync(customer.Cart.Id);
            if(cart == null || cart.Items.Count == 0)
            {
                throw new ServiceException("cart_was_null", "Cannot create order with empty cart");
            }

            Address shippingAddress = new Address(request.ShippingAddress.FirstName,
                request.ShippingAddress.LastName, request.ShippingAddress.Street, request.ShippingAddress.City,
                request.ShippingAddress.PostCode, request.ShippingAddress.Country, request.ShippingAddress.PhoneNumber);

            Address billingAddress = new Address(request.BillingAddress.FirstName,
               request.BillingAddress.LastName, request.BillingAddress.Street, request.BillingAddress.City,
               request.BillingAddress.PostCode, request.BillingAddress.Country, request.BillingAddress.PhoneNumber);

            Order order = new Order(customer, cart.Items, shippingAddress, billingAddress);

            await _orderRepository.AddAsync(order);
            await _orderRepository.Save();

            return Unit.Value;
        }
    }
}
