using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task RemoveAsync(Customer customer);
        Task Save();
    }
}
