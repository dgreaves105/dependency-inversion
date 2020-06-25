using Data.Entities;
using Data.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Queries
{
    public class GetOrders
    {
        public class Query : IRequest<IEnumerable<OrderEntity>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<OrderEntity>>
        {
            private readonly IOrderRepository _repository;

            public Handler(IOrderRepository repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<IEnumerable<OrderEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}
