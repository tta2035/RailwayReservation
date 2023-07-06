using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.DTO
{
    public class BookingTicketResponse
    {
        public Guid BookingId { get; set; }

        public Guid TicketId { get; set; }

        public string? Description { get; set; } = null!;

        public Guid? CreateBy { get; set; } = null!;

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; } = null!;

        public DateTime? UpdateTime { get; set; } = null!;

        public BookingTicketResponse(Guid bookingId, Guid ticketId, string? description, Guid? createBy, DateTime createTime, Guid? updateBy, DateTime? updateTime)
        {
            BookingId = bookingId;
            TicketId = ticketId;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }

        public BookingTicketResponse()
        {
        }
    }
}