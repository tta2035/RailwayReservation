using MediatR;
using RailwayReservation.Application.BookingTicket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Queries
{
    public class GetBookingTicketByTicketQuery : IRequest<List<BookingTicketResponse>>
    {
        public Guid TicketId { get; set; }
    }
}