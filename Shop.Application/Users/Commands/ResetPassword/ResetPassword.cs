using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.ResetPassword
{
    public class ResetPassword : IRequest
    {
        public string SecurityCode { get; set; }
        public string NewPassword { get; set; }
    }
}
