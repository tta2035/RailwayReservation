using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Route.Commands;

namespace RailwayReservation.Application.Route.Handler
{
    public class DeleteRouteHandler : IRequestHandler<DeleteRouteCommand, int>
    {
        private readonly IRouteRepository _routeRepository;

        public DeleteRouteHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<int> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.getById(request.id);
            if(route is null) return default;
            return await _routeRepository.Delete(request.id);
        }
    }
}
