using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.SeatType.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.SeatType;

public sealed class SeatType : AggregateRoot<SeatTypeId, Guid>
{
    // public SeatTypeId SeatTypeId { get; set; }

    public string SeatTypeName { get; set; } = null!;

    public decimal RaitoFare { get; set; }

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<Seat.Seat> Seats { get; set; } = new List<Seat.Seat>();

private SeatType() {}
    public SeatType(
        SeatTypeId seatTypeId,
        string seatTypeName,
        decimal raitoFare,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(seatTypeId)
    {
        // SeatTypeId = seatTypeId;
        SeatTypeName = seatTypeName;
        RaitoFare = raitoFare;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static SeatType Create(string seatTypeName, decimal raitoFare, string? description)
    {
        return new(
            SeatTypeId.CreateUnique(),
            seatTypeName,
            raitoFare,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
