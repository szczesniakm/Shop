using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetBySlugAsync(string slug);
        Task UpdateAsync(Product product);
        Task Save();
    }
}
