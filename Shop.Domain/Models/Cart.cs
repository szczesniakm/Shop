using System;
using System.Collections.ObjectModel;

namespace Shop.Domain.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public ReadOnlyCollection<ProductItem> Items { get; set; }
    }
}