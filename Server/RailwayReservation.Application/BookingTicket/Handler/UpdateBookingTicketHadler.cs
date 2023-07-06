using MediatR;
using RailwayReservation.Application.BookingTicket.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Handler
{
    public class UpdateBookingTicketHadler : IRequestHandler<UpdateBookingTicketCommand, int>
    {
        private readonly IBookingTicketRepository _repo;

        public UpdateBookingTicketHadler(IBookingTicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UpdateBookingTicketCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetBy2Id(request.BookingId, request.TicketId);

            item.BookingId = request.BookingId;
            item.TicketId = request.TicketId;
            item.Description = request.Description;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;
             
             return await _repo.Update(item);
        }
    }
}