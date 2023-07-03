using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Route.DTO;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IRouteRepository : IGenericRepository<Domain.Route.Route, RouteResponse>
    {
        Task<RouteResponse> getRouteResponse(Guid id);
    }
}