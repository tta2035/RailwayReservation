using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Station.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Station;

public sealed class Station : AggregateRoot<StationId, Guid>
{
    public StationId Id { get; set; }

    public string StationName { get; set; } = null!;

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<Route.Route>? RouteDepartureStationNavigations { get; set; } =
        new List<Route.Route>();

    public ICollection<Route.Route>? RouteDestinationStationNavigations { get; set; } =
        new List<Route.Route>();

    private Station() { }

    public Station(
        StationId stationId,
        string stationName,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(stationId)
    {
        // StationId = stationId;
        StationName = stationName;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Station Create(string stationName, string? description)
    {
        return new(
            StationId.CreateUnique(),
            stationName,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
