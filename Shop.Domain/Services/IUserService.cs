using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string email, string password);
        Task VerifyEmail(string securityCode);
        Task RegisterUser(string email, string password);
        Task ChangePasssword(Guid userId, string newPassword);
    }
}
