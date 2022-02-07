using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Messages
{
    public class Edit
    {
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
                try
                {
                    var message = await context.Messages.FindAsync(request.Message.Id);
                
                    message.Unread = request.Message.Unread;

                    await context.SaveChangesAsync();

                    return Unit.Value;
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
                
            }
        }
    }
}