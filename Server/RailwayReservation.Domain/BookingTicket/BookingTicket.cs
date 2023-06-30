using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.BookingTicket.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Ticket.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.BookingTicket;

public sealed class BookingTicket
//  : AggregateRoot<BookingTicketId, Guid>
{
    // public BookingTicketId BookingTicketId { get; set; }
    public BookingId BookingId { get; set; }

    public TicketId TicketId { get; set; }

    public string? Description { get; set; } = null!;

    public UserId? CreateBy { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; } = null!;

    public DateTime? UpdateTime { get; set; } = null!;

    public Booking.Booking Booking { get; set; } = null!;

    public Ticket.Ticket Ticket { get; set; } = null!;

    private BookingTicket() {}

    public BookingTicket(
        // BookingTicketId bookingTicketId,
        BookingId bookingId,
        TicketId ticketId,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
    {
        // BookingTicketId = bookingTicketId;
        BookingId = bookingId;
        TicketId = ticketId;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static BookingTicket Create(
        BookingId bookingId,
        TicketId ticketId,
        string? description
    )
    {
        return new(
            // BookingTicketId.CreateUnique(),
            bookingId,
            ticketId,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
