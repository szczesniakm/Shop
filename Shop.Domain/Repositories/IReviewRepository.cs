using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task AddAsync(Review review);
        Task<Review> GetAsync(Guid id);
        Task UpdateAsync(Review review);
        Task RemoveAsync(Review review);
        Task Save();
    }
}
