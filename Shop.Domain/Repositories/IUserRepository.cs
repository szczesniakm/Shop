using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetBySecurityCodeAsync(string securityCode);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
        Task Save();
    }
}
