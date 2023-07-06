using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Train;

public sealed class Train// : AggregateRoot<TrainId, Guid>
{
    public Guid Id { get; set; }
    public string TrainName { get; set; } = null!;

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<Coach.Coach> Coaches { get; set; } = new List<Coach.Coach>();
    public ICollection<Trip.Trip> Trips { get; set; } = new List<Trip.Trip>();

    private Train() { }

    public Train(
        Guid trainId,
        string trainName,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        // TrainId = trainId;
        TrainName = trainName;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    public static Train Create(string trainName, string? description, Guid? createBy)
    {
        return new(
            new Guid(),
            trainName,
            description,
            createBy,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
