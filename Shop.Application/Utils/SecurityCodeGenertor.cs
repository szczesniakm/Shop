using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Utils
{
    public class SecurityCodeGenertor
    {
        public static string GenerateSecurityCode()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var securityCodeData = new byte[128];
                randomNumberGenerator.GetBytes(securityCodeData);
                var securityCode = Convert.ToBase64String(securityCodeData);
                return securityCode;
            }
        }
    }
}
