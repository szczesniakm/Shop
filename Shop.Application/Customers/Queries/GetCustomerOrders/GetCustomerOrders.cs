using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Queries.GetCustomerOrders
{
    public class GetCustomerOrders : IRequest<IEnumerable<OrderDto>>
    {
        public Guid Id { get; set; }
    }
}
