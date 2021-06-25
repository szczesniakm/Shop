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
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly ShopContext _context;
        public UserRepository(ShopContext shopContext)
        {
            _context = shopContext ?? throw new ArgumentNullException(nameof(shopContext));
            _users = _context.Users;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _users.FindAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetBySecurityCodeAsync(string securityCode)
        {
            return await _users.FirstOrDefaultAsync(u => u.SecurityCode == securityCode);
        }
    }
}
