using Data.Entities;
using Data.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Commands
{
    public class CreateOrder
    {
        public class Command : IRequest<int>
        {
            public OrderEntity Order { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IOrderRepository _repository;

            public Handler(IOrderRepository repository)
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
