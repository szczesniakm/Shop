using AutoMapper;
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
    public class GetCustomerDetailsHandler : IRequestHandler<GetCustomerDetails, CustomerDetailsDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerDetailsHandler(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        async Task<CustomerDetailsDto> IRequestHandler<GetCustomerDetails, CustomerDetailsDto>.Handle(GetCustomerDetails request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetAsync(request.Id);

            return _mapper.Map<CustomerDetailsDto>(result);
        }
    }
}
