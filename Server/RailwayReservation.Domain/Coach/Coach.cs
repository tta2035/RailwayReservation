﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Coach;

public sealed class Coach// : AggregateRoot<CoachId, Guid>
{
    public Guid Id { get; set; }

    public string CoachNo { get; set; } = null!;

    public Guid TrainId { get; set; }

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }
[JsonIgnore]
    public ICollection<Seat.Seat> Seats { get; set; } = new List<Seat.Seat>();
[JsonIgnore]
    public Train.Train Train { get; set; } = null!;

    private Coach() {}

    public Coach(
        Guid coachId,
        string coachNo,
        Guid trainId,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
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

    public static Coach Create(string coachNo, Guid trainId, Guid? createBy, string? description)
    {
        return new(
            new Guid(),
            coachNo,
            trainId,
            description,
            createBy,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
