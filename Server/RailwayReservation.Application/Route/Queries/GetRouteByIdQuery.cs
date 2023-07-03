using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Route.DTO;

namespace RailwayReservation.Application.Route.Queries
{
    public class GetRouteByIdQuery : IRequest<RouteResponse>
    {
        public Guid Id { get; set; }
    }
}