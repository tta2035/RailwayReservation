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
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Ticket;

public sealed class Ticket : AggregateRoot<TicketId, Guid>
{
    // public TicketId TicketId { get; set; }

    public RouteId RouteId { get; set; }

    public TrainId TrainId { get; set; }

    public SeatId SeatId { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArriveTime { get; set; }

    public decimal? Fare { get; set; }

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<BookingTicket.BookingTicket> BookingTickets { get; set; } =
        new List<BookingTicket.BookingTicket>();

private Ticket() {}
    public Ticket(
        TicketId ticketId,
        RouteId routeId,
        TrainId trainId,
        SeatId seatId,
        DateTime departureTime,
        DateTime arriveTime,
        decimal? fare,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(ticketId)
    {
        // TicketId = ticketId;
        RouteId = routeId;
        TrainId = trainId;
        SeatId = seatId;
        DepartureTime = departureTime;
        ArriveTime = arriveTime;
        Fare = fare;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Ticket Create(
        RouteId routeId,
        TrainId trainId,
        SeatId seatId,
        DateTime departureTime,
        DateTime arriveTime,
        decimal? fare,
        string? description
    )
    {
        return new(
            TicketId.CreateUnique(),
            routeId,
            trainId,
            seatId,
            departureTime,
            arriveTime,
            fare,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
