using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Coach.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Coach;

public sealed class Coach : AggregateRoot<CoachId, Guid>
{
    public CoachId Id { get; set; }

    public string CoachNo { get; set; } = null!;

    public TrainId TrainId { get; set; }

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<Seat.Seat> Seats { get; set; } = new List<Seat.Seat>();

    public Train.Train Train { get; set; } = null!;

    private Coach() {}

    public Coach(
        CoachId coachId,
        string coachNo,
        TrainId trainId,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(coachId)
    {
        // CoachId = coachId;
        CoachNo = coachNo;
        TrainId = trainId;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Coach Create(string coachNo, TrainId trainId, string? description)
    {
        return new(
            CoachId.CreateUnique(),
            coachNo,
            trainId,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
