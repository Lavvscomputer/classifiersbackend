﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Classifiers.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        // internal Guid Id => !Id
    }
}
