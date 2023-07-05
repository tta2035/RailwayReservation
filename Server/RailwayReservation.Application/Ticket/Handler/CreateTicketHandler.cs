using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Ticket.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Handler
{
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, Domain.Ticket.Ticket>
    {
        private readonly ITicketRepository _repo;

        public CreateTicketHandler(ITicketRepository repo)
        {
            _repo = repo;
        }

        public Task<Domain.Ticket.Ticket> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}