using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Station.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Application.Route.Commands
{
    public class UpdateRouteCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public string RouteName { get; set; } = null!;

        public Guid DepartureStation { get; set; }

        public Guid DestinationStation { get; set; }

        public decimal RouteFare { get; set; }

        public string? Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateRouteCommand(
            Guid id,
            string routeName,
            Guid departureStation,
            Guid destinationStation,
            decimal routeFare,
            string? description,
            Guid? updateBy,
            DateTime? updateTime
        )
        {
            Id = id;
            RouteName = routeName;
            DepartureStation = departureStation;
            DestinationStation = destinationStation;
            RouteFare = routeFare;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}
