using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Route.Commands;

namespace RailwayReservation.Application.Route.Handler
{
    public class UpdateRouteHandler : IRequestHandler<UpdateRouteCommand, int>
    {
        private readonly IRouteRepository _routeRepository;

        public UpdateRouteHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<int> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            var findRoute = _routeRepository.getById(request.Id).Result;
            if(findRoute == null) return default;

            var newRoute = new Domain.Route.Route(
                request.Id,
                request.RouteName,
                request.DepartureStation,
                request.DestinationStation,
                request.RouteFare,
                request.Description,
                findRoute.CreateBy,
                findRoute.CreateTime,
                request.UpdateBy,
                request.UpdateTime
            );
            return await _routeRepository.Update(newRoute);
        }
    }
}
