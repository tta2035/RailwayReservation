using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Ticket.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Handler
{
    public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, int>
    {
        private readonly ITicketRepository _repo;

        public DeleteTicketHandler(ITicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(request.Id);
        }
    }
}