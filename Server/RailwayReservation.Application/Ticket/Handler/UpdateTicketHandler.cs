using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Ticket.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Handler
{
    public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, int>
    {
        private readonly ITicketRepository _repo;

        public UpdateTicketHandler(ITicketRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}