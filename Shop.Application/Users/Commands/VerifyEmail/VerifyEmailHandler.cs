using MediatR;
using Shop.Domain.Repositories;
using Shop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.VerifyEmail
{
    public class VerifyEmailHandler : IRequestHandler<VerifyEmail>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public VerifyEmailHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<Unit> Handle(VerifyEmail request, CancellationToken cancellationToken)
        {
            await _userService.VerifyEmail(request.SecurityCode);
            await _userRepository.Save();
            return Unit.Value;
        }
    }
}
