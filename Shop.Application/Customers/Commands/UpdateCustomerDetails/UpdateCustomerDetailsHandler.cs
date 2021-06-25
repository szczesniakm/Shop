using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Models;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Commands.UpdateCustomerDetails
{
    public class UpdateCustomerDetailsHandler : IRequestHandler<UpdateCustomerDetails>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        public UpdateCustomerDetailsHandler(ICustomerRepository customerRepository,
            IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerDetails request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if(user == null)
            {
                throw new ServiceException("user_does_not_exist.", $"User with Id {request.Id} was not found.");
            }
            var customer = await _customerRepository.GetAsync(request.Id);
            if(customer == null)
            {
                customer = new Customer(user, request.FirstName, request.LastName, request.PhoneNumber);
                await _customerRepository.AddAsync(customer);
            }
            else 
            {
                customer.SetDetails(request.FirstName, request.LastName, request.PhoneNumber);
            }

            await _customerRepository.Save();
            return Unit.Value;
        }
    }
}
