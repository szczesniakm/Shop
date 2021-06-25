using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.DbContexts;
using Shop.Domain.Models;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _products = _context.Products;
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _products.FindAsync(id);
        }

        public async Task<Product> GetBySlugAsync(string slug)
        {
            return await _products.Include(p => p.Reviews).FirstOrDefaultAsync(p => p.Slug == slug);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
