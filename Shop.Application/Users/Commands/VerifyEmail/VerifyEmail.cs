using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.VerifyEmail
{
    public class VerifyEmail : IRequest
    {
        public string SecurityCode { get; set; }
    }
}
