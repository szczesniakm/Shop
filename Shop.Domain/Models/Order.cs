using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain.Models
{
    public class Order
    {
        private List<ProductItem> _items = new List<ProductItem>();

        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public IReadOnlyList<ProductItem> Items { get { return _items; } }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public decimal Total
        {
            get { return _items.Sum(x => x.Quantity * x.Product.Price); }
        }
        public OrderStatus Status { get; set; }

        private Order()
        { }

        public Order(Customer customer, IReadOnlyCollection<ProductItem> items, Address shippingAddress, Address billingAddress)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            _items = new List<ProductItem>(items);
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
            Status = OrderStatus.New;
        }
    }
}