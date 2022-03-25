using System;

namespace Shop.Domain.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public Role Role { get; protected set; }
        public string SecurityCode { get; protected set; }
        public DateTime SecurityCodeExpirationDate { get; protected set; }
        public bool EmailConfirmed { get; protected set; }

        private User() { }
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