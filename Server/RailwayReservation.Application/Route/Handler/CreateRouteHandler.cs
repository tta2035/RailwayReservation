using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Route.Commands;

namespace RailwayReservation.Application.Route.Handler
{
    public class CreateRouteHandler : IRequestHandler<CreateRouteCommand, Domain.Route.Route>
    {
        private readonly IRouteRepository _routeRepository;

        public CreateRouteHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Domain.Route.Route> Handle(
            CreateRouteCommand request,
            CancellationToken cancellationToken
        )
        {
            var route = Domain.Route.Route.Create(
                request.RouteName,
                request.DepartureStation,
                request.DestinationStation,
                request.RouteFare,
                request.Description
            );
            return await _routeRepository.Insert(route);
        }
    }
}
