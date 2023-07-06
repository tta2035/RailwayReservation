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

        public async Task<Domain.Ticket.Ticket> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var item = Domain.Ticket.Ticket.Create(
                request.TripId,
                request.SeatId,
                request.Fare,
                request.Description,
                request.Status,
                request.CreateBy
            );
            return await _repo.Insert(item );
        }
    }
}