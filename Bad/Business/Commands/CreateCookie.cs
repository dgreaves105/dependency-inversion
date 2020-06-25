using Data.Entities;
using Data.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Commands
{
    public class CreateCookie
    {
        public class Command : IRequest<int> 
        { 
            public CookieEntity Cookie { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly ICookieRepository _repository;

            public Handler(ICookieRepository repository)
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
