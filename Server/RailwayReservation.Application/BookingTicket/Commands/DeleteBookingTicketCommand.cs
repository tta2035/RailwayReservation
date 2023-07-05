using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Commands
{
    public class DeleteBookingTicketCommand : IRequest<int>
    {
        public Guid BookingId { get; set; }
        public Guid TicketId { get; set; }
    }
}