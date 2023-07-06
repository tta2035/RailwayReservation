﻿using System;
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
// // : AggregateRoot<BookingTicketId, Guid>
{
    // public BookingTicketId BookingTicketId { get; set; }
    public Guid BookingId { get; set; }

    public Guid TicketId { get; set; }

    public string? Description { get; set; } = null!;

    public Guid? CreateBy { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; } = null!;

    public DateTime? UpdateTime { get; set; } = null!;

    public Booking.Booking Booking { get; set; } = null!;

    public Ticket.Ticket Ticket { get; set; } = null!;

    private BookingTicket() {}

    public BookingTicket(
        // BookingTicketId bookingTicketId,
        Guid bookingId,
        Guid ticketId,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
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

    public static BookingTicket Create(
        Guid bookingId,
        Guid ticketId,
        string? description,
        Guid? createBy
    )
    {
        return new(
            // BookingTicketId.CreateUnique(),
            bookingId,
            ticketId,
            description,
            createBy,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
