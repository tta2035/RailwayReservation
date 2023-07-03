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

public sealed class Route// : AggregateRoot<RouteId, Guid>
{
    public Guid Id { get; set; }

    public string RouteName { get; set; } = null!;

    public Guid DepartureStation { get; set; }

    public Guid DestinationStation { get; set; }

    public decimal RouteFare { get; set; }

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public Station.Station DepartureStationNavigation { get; set; } = null!;

    //public IReadOnlyList<Station.Station> DepartureStationNavigation => _departureStationNavigation.AsReadOnly();

    public Station.Station DestinationStationNavigation { get; set; } = null!;

    public ICollection<Trip.Trip> Trips { get; set; } = new List<Trip.Trip>();

    public Route(
        Guid routeId,
        string routeName,
        Guid departureStation,
        Guid destinationStation,
        decimal routeFare,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
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

    public static Route Create(
        string routeName,
        Guid departureStation,
        Guid destinationStation,
        decimal routeFare,
        string? description
    )
    {
        return new(
            new Guid(),
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
