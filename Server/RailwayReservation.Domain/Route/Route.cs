using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Station.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Route;

public sealed class Route : AggregateRoot<RouteId, Guid>
{
    public RouteId Id { get; set; }

    public string RouteName { get; set; } = null!;

    public StationId DepartureStation { get; set; }

    public StationId DestinationStation { get; set; }

    public decimal RouteFare { get; set; }

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public Station.Station DepartureStationNavigation { get; set; } = null!;

    //public IReadOnlyList<Station.Station> DepartureStationNavigation => _departureStationNavigation.AsReadOnly();

    public Station.Station DestinationStationNavigation { get; set; } = null!;

    public ICollection<Trip.Trip> Trips { get; set; } = new List<Trip.Trip>();

    public Route(
        RouteId routeId,
        string routeName,
        StationId departureStation,
        StationId destinationStation,
        decimal routeFare,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(routeId)
    {
        // RouteId = routeId;
        RouteName = routeName;
        DepartureStation = departureStation;
        DestinationStation = destinationStation;
        RouteFare = routeFare;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private Route() { }

    private static Route Create(
        string routeName,
        StationId departureStation,
        StationId destinationStation,
        decimal routeFare,
        string? description
    )
    {
        return new(
            RouteId.CreateUnique(),
            routeName,
            departureStation,
            destinationStation,
            routeFare,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
