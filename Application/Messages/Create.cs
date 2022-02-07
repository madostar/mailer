using Domain;
using MediatR;
using Persistence;

namespace Application.Messages
{
    public class Create {

    public class Command : IRequest
    {
        public Message Message {get ; set;}
    }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Messages.Add(request.Message);
                
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}