using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator;

        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
