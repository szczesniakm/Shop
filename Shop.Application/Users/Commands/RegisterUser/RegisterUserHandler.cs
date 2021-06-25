using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Models;
using Shop.Domain.Repositories;
using Shop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public RegisterUserHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<Unit> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            await _userService.RegisterUser(request.Email, request.Password);
            await _userRepository.Save();

            return Unit.Value;
        }
    }
}
