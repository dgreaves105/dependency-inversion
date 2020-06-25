using Data.Entities;
using Data.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Queries
{
    public class GetCookies
    {
        public class Query : IRequest<IEnumerable<CookieEntity>> {}

        public class Handler : IRequestHandler<Query, IEnumerable<CookieEntity>>
        {
            private readonly ICookieRepository _repository;

            public Handler(ICookieRepository repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<IEnumerable<CookieEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}
