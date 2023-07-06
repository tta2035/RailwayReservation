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

        public async Task<int> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);

            item.TripId = request.TripId;
            item.SeatId = request.SeatId;
            item.Fare = request.Fare;
            item.Description = request.Description;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;

            return await _repo.Update(item);
        }
    }
}