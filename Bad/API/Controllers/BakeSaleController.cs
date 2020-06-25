using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Commands;
using Business.Queries;
using Data.Entities;
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

        [HttpGet("Cookie")]
        [ProducesResponseType(typeof(IEnumerable<CookieEntity>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<CookieEntity>> GetCookies()
        {
            return (await _mediator.Send(new GetCookies.Query()));
        }

        [HttpPost("Cookie")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public async Task<int> CreateCookie(CookieEntity cookie)
        {
            return await _mediator.Send(new CreateCookie.Command { Cookie = cookie });
        }

        [HttpGet("Order")]
        [ProducesResponseType(typeof(IEnumerable<OrderEntity>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<OrderEntity>> GetOrders()
        {
            return (await _mediator.Send(new GetOrders.Query()));
        }

        [HttpPost("Order")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public async Task<int> PlaceOrder(OrderEntity cookie)
        {
            return await _mediator.Send(new CreateOrder.Command { Order = cookie });
        }
    }
}
