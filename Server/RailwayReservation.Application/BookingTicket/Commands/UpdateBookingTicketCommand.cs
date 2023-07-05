using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Commands
{
    public class UpdateBookingTicketCommand : IRequest<int>
    {
        public Guid BookingId { get; set; }

        public Guid TicketId { get; set; }

        public string? Description { get; set; } = null!;

        public Guid? UpdateBy { get; set; } = null!;

        public DateTime? UpdateTime { get; set; } = null!;

        public UpdateBookingTicketCommand(Guid bookingId, Guid ticketId, string? description, Guid? updateBy, DateTime? updateTime)
        {
            BookingId = bookingId;
            TicketId = ticketId;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}