using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BakeSaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BakeSaleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cookie>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Cookie>> GetCookies()
        {
            return (await _mediator.Send(new GetCookies.Query()));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public async Task<int> PlaceOrder(Cookie cookie)
        {
            return await _mediator.Send(new CreateCookie.Command { Cookie = cookie });
        }
    }
}
