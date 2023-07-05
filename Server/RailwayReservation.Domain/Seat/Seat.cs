using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Coach.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Seat.ValueObjects;
using RailwayReservation.Domain.SeatType.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Seat;

public sealed class Seat// : AggregateRoot<SeatId, Guid>
{
    public Guid Id { get; set; }

    public Guid CoachId { get; set; }

    public Guid SeatTypeId { get; set; }

    public string SeatNo { get; set; }

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public Coach.Coach Coach { get; set; } = null!;

    public SeatType.SeatType SeatType { get; set; } = null!;
    public ICollection<Ticket.Ticket> Tickets { get; set; } = new List<Ticket.Ticket>();

    private Seat() {}
    public Seat(
        Guid seatId,
        Guid coachId,
        Guid seatTypeId,
        string seatNo,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        // SeatId = seatId;
        CoachId = coachId;
        SeatTypeId = seatTypeId;
        SeatNo = seatNo;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Seat Create(
        Guid coachId,
        Guid seatTypeId,
        string seatNo,
        string? description,
        Guid? createBy
    )
    {
        return new(
            new Guid(),
            coachId,
            seatTypeId,
            seatNo,
            description,
            createBy,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
