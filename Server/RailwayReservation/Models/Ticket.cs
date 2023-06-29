using System;
using System.Collections.Generic;

namespace RailwayReservation.Api.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int RouteId { get; set; }

    public int TrainId { get; set; }

    public int SeatId { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArriveTime { get; set; }

    public decimal? Fare { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<BookingTicket> BookingTickets { get; set; } = new List<BookingTicket>();
}
