using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shop.Domain.Models
{
    public class Cart
    {
        private List<ProductItem> _items = new List<ProductItem>();
        
        public Guid Id { get; set; }
        public IReadOnlyList<ProductItem> Items { get { return _items; } }
        public decimal Total
        {
            get { return _items.Sum(x => x.Quantity * x.Product.Price); }
        }

        public Customer Customer { get; set; }
        public Guid? CustomerId { get; set; }

        public Cart()
        {
            Id = Guid.NewGuid();
        }

        public void AddProductItem(ProductItem productItem)
        {
            var item = _items.FirstOrDefault(p => p.Product.Id == productItem.Product.Id);
            if (item != null)
            {
                if (productItem.Quantity < 1)
                    _items.Remove(item);
                else
                    item.Quantity = productItem.Quantity;
                return;
            }
            if (productItem.Quantity < 1)
                return;
            _items.Add(productItem);
        }

    }
}