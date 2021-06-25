using MediatR;
using Shop.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.Login
{
    public class Login : IRequest<JwtDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
