using System;
using System.Collections.Generic;

namespace RailwayReservation.Api.Models;

public partial class BookingTicket
{
    public int BookingId { get; set; }

    public int TicketId { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
