using System;

namespace Shop.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Cart Cart { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}