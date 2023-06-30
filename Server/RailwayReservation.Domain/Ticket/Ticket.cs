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

public sealed class Ticket : AggregateRoot<TicketId, Guid>
{
    public TicketId Id { get; set; }

    public TripId TripId { get; set; }

    public SeatId SeatId { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArriveTime { get; set; }

    public decimal? Fare { get; set; }

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }
    public string Status { get; set; }

    public ICollection<BookingTicket.BookingTicket> BookingTickets { get; set; } =
        new List<BookingTicket.BookingTicket>();

    public Seat.Seat Seat { get; set; } = null!;

    public Trip.Trip Trip { get; set; }

    private Ticket() { }

    public Ticket(
        TicketId ticketId,
        TripId tripId,
        SeatId seatId,
        DateTime departureTime,
        DateTime arriveTime,
        decimal? fare,
        string? description,
        string status,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime        
    )
        : base(ticketId)
    {
        // TicketId = ticketId;
        TripId = tripId;
        SeatId = seatId;
        DepartureTime = departureTime;
        ArriveTime = arriveTime;
        Fare = fare;
        Description = description;
        Status = status;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
        
    }

    private static Ticket Create(
        TripId tripId,
        SeatId seatId,
        DateTime departureTime,
        DateTime arriveTime,
        decimal? fare,
        string? description,
        string status
    )
    {
        return new(
            TicketId.CreateUnique(),
            tripId,
            seatId,
            departureTime,
            arriveTime,
            fare,
            description,
            status,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
