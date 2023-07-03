using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Route.Queries;
using RailwayReservation.Application.Route.DTO;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Application.Route.Handler
{
    public class GetRouteByIdHandler : IRequestHandler<GetRouteByIdQuery, RouteResponse>
    {
        private readonly IRouteRepository _routeRepository;

        public GetRouteByIdHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<RouteResponse> Handle(
            GetRouteByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var routeFind = await _routeRepository.getRouteResponse(request.Id);
            if(request is null) return null;
            return routeFind;
        }
    }
}
