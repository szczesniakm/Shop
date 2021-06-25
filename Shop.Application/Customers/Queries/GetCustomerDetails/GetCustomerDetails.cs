using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetails : IRequest<CustomerDetails>
    {
        public Guid Id { get; set; }
    }
}
