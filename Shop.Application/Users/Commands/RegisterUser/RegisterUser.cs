using MediatR;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Commands.RegisterUser
{
    public class RegisterUser : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
