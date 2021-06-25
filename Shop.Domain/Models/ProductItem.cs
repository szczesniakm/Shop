using System;

namespace Shop.Domain.Models
{
    public class ProductItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity  {get; set; }

        public ProductItem()
        { }

        public ProductItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}