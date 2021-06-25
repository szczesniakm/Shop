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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _customers = _context.Customers;
        }

        public async Task AddAsync(Customer customer)
        {
            await _customers.AddAsync(customer);
        }

        public async Task<Customer> GetAsync(Guid id)
        {
            return await _customers.Include(c => c.Cart).Include(c => c.Orders).FirstOrDefaultAsync(c => c.UserId == id);
        }

        public async Task RemoveAsync(Customer customer)
        {
            _customers.Remove(customer);
            await Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
