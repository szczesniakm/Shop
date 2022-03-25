using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.DbContexts;
using Shop.Domain.Models;
using Shop.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ShopContext _context;
        private readonly DbSet<Cart> _carts;

        public CartRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _carts = _context.Carts;
        }

        public async Task AddAsync(Cart cart)
        {
            await _carts.AddAsync(cart);
        }

        public async Task<Cart> GetAsync(Guid id)
        {
            return await _carts.Include(c => c.Items).ThenInclude(i => i.Product).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task RemoveAsync(Cart cart)
        {
            _carts.Remove(cart);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
