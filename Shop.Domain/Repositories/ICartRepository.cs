using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface ICartRepository
    {
        Task AddAsync(Cart cart);
        Task<Cart> GetAsync(Guid id);
        Task UpdateAsync(Cart cart);
        Task RemoveAsync(Cart cart);
        Task Save();
    }
}
