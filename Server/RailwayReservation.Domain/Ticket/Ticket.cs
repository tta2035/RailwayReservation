using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Seat.ValueObjects;
using RailwayReservation.Domain.Ticket.ValueObjects;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.Trip.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Ticket;

public sealed class Ticket// : AggregateRoot<TicketId, Guid>
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public Guid SeatId { get; set; }

    public decimal? Fare { get; set; }

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }
    public string Status { get; set; }

    public ICollection<BookingTicket.BookingTicket> BookingTickets { get; set; } =
        new List<BookingTicket.BookingTicket>();

    public Seat.Seat Seat { get; set; } = null!;

    public Trip.Trip Trip { get; set; }

    private Ticket() { }

    public Ticket(
        Guid ticketId,
        Guid tripId,
        Guid seatId,
        decimal? fare,
        string? description,
        string status,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime        
    )
    {
        // TicketId = ticketId;
        TripId = tripId;
        SeatId = seatId;
        Fare = fare;
        Description = description;
        Status = status;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
        
    }

    public static Ticket Create(
        Guid tripId,
        Guid seatId,
        decimal? fare,
        string? description,
        string status,
        Guid? createBy
    )
    {
        return new(
            new Guid(),
            tripId,
            seatId,
            fare,
            description,
            status,
            createBy,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
