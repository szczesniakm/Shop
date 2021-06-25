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
    public class ReviewRepository : IReviewRepository
    {
        private readonly ShopContext _context;
        private readonly DbSet<Review> _reviews;

        public ReviewRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _reviews = _context.Reviews;
        }

        public async Task AddAsync(Review review)
        {
            await _reviews.AddAsync(review);
        }

        public async Task<Review> GetAsync(Guid id)
        {
            return await _reviews.FindAsync(id);
        }

        public async Task RemoveAsync(Review review)
        {
            _reviews.Remove(review);
            await Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
