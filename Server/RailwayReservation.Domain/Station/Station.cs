using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Station;

public sealed class Station // : AggregateRoot<StationId, Guid>
{
    public Guid Id { get; set; }

    public string StationName { get; set; }

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    [JsonIgnore]
    public ICollection<Route.Route>? RouteDepartureStationNavigations { get; set; } =
        new List<Route.Route>();

    [JsonIgnore]
    public ICollection<Route.Route>? RouteDestinationStationNavigations { get; set; } =
        new List<Route.Route>();

    public Station() { }

    public Station(
        Guid stationId,
        string stationName,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        // StationId = stationId;
        StationName = stationName;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    public static Station Create(string stationName, string? description)
    {
        return new(
            new Guid(),
            stationName,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
