using Application.Abstractions;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateCookie
    {
        public class Command : IRequest<int> 
        { 
            public Cookie Cookie { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IRepository<Cookie> _repository;

            public Handler(IRepository<Cookie> repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _repository.Create(request.Cookie);
            }
        }
    }
}
