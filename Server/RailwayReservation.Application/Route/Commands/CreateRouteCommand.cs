using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Route.Commands
{
    public class CreateRouteCommand : IRequest<Domain.Route.Route>
    {
        public string RouteName { get; set; } = null!;

        public Guid DepartureStation { get; set; }

        public Guid DestinationStation { get; set; }

        public decimal RouteFare { get; set; }

        public string? Description { get; set; } = null!;

        public Guid? CreateBy { get; set; } = null!;

        public DateTime CreateTime { get; set; }

        public CreateRouteCommand(
            string routeName,
            Guid departureStation,
            Guid destinationStation,
            decimal routeFare,
            string? description,
            Guid? createBy,
            DateTime createTime
        )
        {
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
