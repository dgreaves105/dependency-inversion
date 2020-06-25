using Application.Abstractions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetOrders
    {
        public class Query : IRequest<IEnumerable<CookieOrder>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<CookieOrder>>
        {
            private readonly IRepository<CookieOrder> _repository;

            public Handler(IRepository<CookieOrder> repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<IEnumerable<CookieOrder>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}
