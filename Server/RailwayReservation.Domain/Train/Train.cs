using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Train;

public sealed class Train : AggregateRoot<TrainId, Guid>
{
    public TrainId Id { get; set; }
    public string TrainName { get; set; } = null!;

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<Coach.Coach> Coaches { get; set; } = new List<Coach.Coach>();
    public ICollection<Ticket.Ticket> Tickets { get; set; } = new List<Ticket.Ticket>();

    private Train() { }

    public Train(
        TrainId trainId,
        string trainName,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(trainId)
    {
        // TrainId = trainId;
        TrainName = trainName;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Train Create(string trainName, string? description)
    {
        return new(
            TrainId.CreateUnique(),
            trainName,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
