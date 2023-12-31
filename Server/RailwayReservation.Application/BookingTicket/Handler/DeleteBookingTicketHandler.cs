using MediatR;
using RailwayReservation.Application.BookingTicket.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Handler
{
    public class DeleteBookingTicketHandler : IRequestHandler<DeleteBookingTicketCommand, int>
    {
        private readonly IBookingTicketRepository _repo;

        public DeleteBookingTicketHandler(IBookingTicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeleteBookingTicketCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteBy2Id(request.BookingId, request.TicketId);
        }
    }
}