using Microsoft.AspNetCore.Identity;
using Shop.Application.Exceptions;
using Shop.Application.Utils;
using Shop.Domain.Models;
using Shop.Domain.Repositories;
using Shop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            var user = await _userRepository.GetByEmailAsync(email);
            if(user == null)
            {
                return false;
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Success)
            {
                return true;
            }
            else return false;
        }

        public async Task VerifyEmail(string securityCode)
        {
            if(string.IsNullOrWhiteSpace(securityCode))
            {
                throw new ServiceException("invalid_security_code", "Security code is invalid.");
            }
            var user = await _userRepository.GetBySecurityCodeAsync(securityCode);
            if(user == null)
            {
                throw new ServiceException("invalid_security_code", "Security code is invalid.");
            }
            if(user.SecurityCodeExpirationDate < DateTime.UtcNow)
            {
                throw new ServiceException("security_code_expired", "Activation link has expired.");
            }
            user.VerifyEmail();
        }

        public async Task RegisterUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ServiceException("invalid_credentials", "Invalid credentials.");
            }
            var user = await _userRepository.GetByEmailAsync(email);
            if(user != null)
            {
                throw new ServiceException("user_already_exists", $"User with email {email} already exists.");
            }
            var securityCode = SecurityCodeGenertor.GenerateSecurityCode();
            var securityCodeExpiration = DateTime.UtcNow.AddDays(7);
            User newUser = new(Guid.NewGuid(), email, password, DateTime.UtcNow, Role.User, securityCode, securityCodeExpiration, false);
            newUser.SetPassword(_passwordHasher.HashPassword(newUser, password));
            await _userRepository.AddAsync(newUser);
        }

        public async Task ChangePasssword(Guid userId, string newPassword)
        {
            var user = await _userRepository.GetAsync(userId);
            if(user == null)
            {
                throw new ServiceException("user_not_exists", $"User with Id {userId} does not exist.");
            }
            user.SetPassword(_passwordHasher.HashPassword(user, newPassword));
        }
    }
}
