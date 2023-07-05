using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.DTO
{
    public class CreateBookingTicketRequest
    {
        public Guid BookingId { get; set; }

        public Guid TicketId { get; set; }

        public string? Description { get; set; } = null!;

        public Guid? CreateBy { get; set; } = null!;

        public DateTime CreateTime { get; set; }

        public CreateBookingTicketRequest(Guid bookingId, Guid ticketId, string? description, Guid? createBy, DateTime createTime)
        {
            BookingId = bookingId;
            TicketId = ticketId;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}