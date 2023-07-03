using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Route.DTO;
using RailwayReservation.Application.Route.Queries;

namespace RailwayReservation.Application.Route.Handler
{
    public class GetRouteListHandler : IRequestHandler<GetRouteListQuery, List<RouteResponse>>
    {
        private readonly IRouteRepository _routeRepository;

        public GetRouteListHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<List<RouteResponse>> Handle(
            GetRouteListQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _routeRepository.GetAll();
            return result;
        }
    }
}
