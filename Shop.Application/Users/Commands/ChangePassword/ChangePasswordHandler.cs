using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Repositories;
using Shop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePassword>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public ChangePasswordHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<Unit> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if (user == null)
            {
                throw new ServiceException("user_not_exists", $"User with Id {request.Id} does not exist.");
            }
            var validationResult = await _userService.ValidateCredentials(user.Email, request.CurrentPassword);
            if(!validationResult)
            {
                throw new ServiceException("invalid_credentials", "Invalid credentials.");
            }
            await _userService.ChangePasssword(request.Id, request.NewPassword);
            await _userRepository.Save();

            return Unit.Value;
        }
    }
}
