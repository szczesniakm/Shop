using MediatR;
using Shop.Application.Exceptions;
using Shop.Application.Utils;
using Shop.Domain.Repositories;
using Shop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.RequestPasswordReset
{
    public class RequestPasswordResetHandler : IRequestHandler<RequestPasswordReset>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public RequestPasswordResetHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<Unit> Handle(RequestPasswordReset request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if(user == null)
            {
                throw new ServiceException("user_does_not_exist", $"User with email {request.Email} does not exist.");
            }
            if(!user.IsActive())
            {
                throw new ServiceException("user_inactive", "Verify your e-mail address.");
            }

            var securityCode = SecurityCodeGenertor.GenerateSecurityCode();
            var securityCodeExpiration = DateTime.UtcNow.AddHours(2);

            user.SetSecurityCode(securityCode, securityCodeExpiration);
            await _userRepository.UpdateAsync(user);
            await _userRepository.Save();

            //TODO send email with security code

            return Unit.Value;
        }
    }
}
