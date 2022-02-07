using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Messages
{
    public class Details
    {
        public class Query : IRequest<Message>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Message>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Message> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Messages.FindAsync(request.Id);
            }
        }
    }
}