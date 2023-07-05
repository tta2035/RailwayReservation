using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.SeatType.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.SeatType;

public sealed class SeatType// : AggregateRoot<SeatTypeId, Guid>
{
    public Guid Id { get; set; }

    public string SeatTypeName { get; set; } = null!;

    public double RaitoFare { get; set; }

    public string? Description { get; set; }

    public Guid CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<Seat.Seat> Seats { get; set; } = new List<Seat.Seat>();

private SeatType() {}
    public SeatType(
        Guid seatTypeId,
        string seatTypeName,
        double raitoFare,
        string? description,
        Guid createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
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

    public static SeatType Create(string seatTypeName, double raitoFare, string? description, Guid createBy)
    {
        return new(
            new Guid(),
            seatTypeName,
            raitoFare,
            description,
            createBy,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
