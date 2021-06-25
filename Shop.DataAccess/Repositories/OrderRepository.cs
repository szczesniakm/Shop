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
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopContext _context;
        private readonly DbSet<Order> _orders;

        public OrderRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _orders = _context.Orders;
        }

        public async Task AddAsync(Order order)
        {
            await _orders.AddAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllUserOrders(Guid customerId)
        {
            return await _orders.Where(o => o.Customer.UserId == customerId).ToListAsync();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _orders.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
