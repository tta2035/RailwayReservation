using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Station.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Application.Route.DTO
{
    public class RouteRequest
    {
        public Guid Id { get; set; }

        public string RouteName { get; set; } = null!;

        public Guid DepartureStation { get; set; }

        public Guid DestinationStation { get; set; }

        public decimal RouteFare { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public RouteRequest(
            Guid id,
            string routeName,
            Guid departureStation,
            Guid destinationStation,
            decimal routeFare,
            string? description,
            Guid? createBy,
            DateTime createTime
        )
        {
            Id = id;
            RouteName = routeName;
            DepartureStation = departureStation;
            DestinationStation = destinationStation;
            RouteFare = routeFare;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}
