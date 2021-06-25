using MediatR;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsHandler : IRequestHandler<GetCustomerDetails, CustomerDetails>
    {
        private ICustomerRepository _customerRepository;

        public GetCustomerDetailsHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        async Task<CustomerDetails> IRequestHandler<GetCustomerDetails, CustomerDetails>.Handle(GetCustomerDetails request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetAsync(request.Id);

            return new CustomerDetails
            {
                FirstName = result.FirstName,
                LastName = result.LastName
            };
        }
    }
}
