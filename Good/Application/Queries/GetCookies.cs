using Application.Abstractions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetCookies
    {
        public class Query : IRequest<IEnumerable<Cookie>> {}

        public class Handler : IRequestHandler<Query, IEnumerable<Cookie>>
        {
            private readonly IRepository<Cookie> _repository;

            public Handler(IRepository<Cookie> repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<IEnumerable<Cookie>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}
