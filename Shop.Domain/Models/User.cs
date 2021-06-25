using System;

namespace Shop.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public Role Role { get; set; }
        public string SecurityCode { get; set; }
        public DateTime SecurityCodeExpirationDate { get; set; }
        public bool EmailConfirmed { get; set; }

        public User(Guid id, string email, string password, DateTime createdOn, Role role, string securityCode, DateTime securityCodeExpirationDate, bool emailConfirmed)
        {
            Id = id;
            Email = email;
            Password = password;
            CreatedOn = createdOn;
            Role = role;
            SecurityCode = securityCode;
            SecurityCodeExpirationDate = securityCodeExpirationDate;
            EmailConfirmed = emailConfirmed;
        }

        public void VerifyEmail()
        {
            EmailConfirmed = true;
            ResetSecurityCode();
        }

        public bool IsActive()
        {
            return EmailConfirmed;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetSecurityCode(string securityCode, DateTime securityCodeExpiration)
        {
            SecurityCode = securityCode;
            SecurityCodeExpirationDate = securityCodeExpiration;
        }

        public void ResetSecurityCode()
        {
            SecurityCode = null;
            SecurityCodeExpirationDate = DateTime.MinValue;
        }
    }
}