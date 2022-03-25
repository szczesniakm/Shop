using Shop.Application.Orders.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Queries.GetCustomerOrders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public AddressDto BillingAddress { get; set; }
        public decimal Total { get; set; }
    }
}
