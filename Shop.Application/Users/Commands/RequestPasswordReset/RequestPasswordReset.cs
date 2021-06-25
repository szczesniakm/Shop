using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.RequestPasswordReset
{
    public class RequestPasswordReset : IRequest
    {
        public string Email { get; set; }
    }
}
