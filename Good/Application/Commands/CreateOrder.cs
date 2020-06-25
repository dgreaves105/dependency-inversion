using Application.Abstractions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateOrder
    {
        public class Command : IRequest<int>
        {
            public CookieOrder Order { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IRepository<CookieOrder> _repository;

            public Handler(IRepository<CookieOrder> repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _repository.Create(request.Order);
            }
        }
    }
}
