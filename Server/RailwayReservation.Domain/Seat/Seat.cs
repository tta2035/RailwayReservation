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

public sealed class Seat : AggregateRoot<SeatId, Guid>
{
    public SeatId Id { get; set; }

    public CoachId CoachId { get; set; }

    public SeatTypeId SeatTypeId { get; set; }

    public string SeatNo { get; set; } = null!;

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public Coach.Coach Coach { get; set; } = null!;

    public SeatType.SeatType SeatType { get; set; } = null!;
    public ICollection<Ticket.Ticket> Tickets { get; set; } = new List<Ticket.Ticket>();

    private Seat() {}
    public Seat(
        SeatId seatId,
        CoachId coachId,
        SeatTypeId seatTypeId,
        string seatNo,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(seatId)
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
        CoachId coachId,
        SeatTypeId seatTypeId,
        string seatNo,
        string? description
    )
    {
        return new(
            SeatId.CreateUnique(),
            coachId,
            seatTypeId,
            seatNo,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
