using Shop.Application.Customers.Queries.GetCustomerOrders;
using System;
using System.Collections.Generic;

namespace Shop.Application.Carts.Queries.GetCart
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
        public decimal Total { get; set; }
    }
}