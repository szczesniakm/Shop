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

namespace Shop.Application.Users.Commands.Login
{
    public class LoginHandler : IRequestHandler<Login, JwtDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public LoginHandler(IUserRepository userRepository, IUserService userService, JwtService jwtService)
        {
            _userRepository = userRepository;
            _userService = userService;
            _jwtService = jwtService;
        }

        async Task<JwtDto> IRequestHandler<Login, JwtDto>.Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ServiceException("user_does_not_exist", $"User with email {request.Email} does not exist.");
            }
            var validationResult = await _userService.ValidateCredentials(request.Email, request.Password);
            if (!validationResult)
            {
                throw new ServiceException("invalid_credentials", "Invalid credentials.");
            }
            if (!user.IsActive())
            {
                throw new ServiceException("user_inactive", "Verify your e-mail address.");
            }
            var token = _jwtService.CreateToken(user.Id, "user");
 
            return token;
        }
    }
}
