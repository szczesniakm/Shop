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

namespace Shop.Application.Users.Commands.ResetPassword
{
    public class ResetPasswordHandler : IRequestHandler<ResetPassword>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public ResetPasswordHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<Unit> Handle(ResetPassword request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySecurityCodeAsync(request.SecurityCode);
            if(user == null)
            {
                throw new ServiceException("invalid_security_code", "Security code is invalid.");
            }
            if (user.SecurityCodeExpirationDate < DateTime.UtcNow)
            {
                throw new ServiceException("security_code_expired", "Activation link has expired.");
            }
            user.ResetSecurityCode();
            await _userService.ChangePasssword(user.Id, request.NewPassword);
            await _userRepository.Save();
            return Unit.Value;
        }
    }
}
