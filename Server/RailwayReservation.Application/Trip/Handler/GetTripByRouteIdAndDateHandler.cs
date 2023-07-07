using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Trip.DTO;
using RailwayReservation.Application.Trip.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Handler;

public class GetTripByRouteIdAndDateHandler : IRequestHandler<GetTripByRouteIdAndDateQuery, List<TripResponse>>
{
    private readonly ITripRepository _repo;

    public GetTripByRouteIdAndDateHandler(ITripRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<TripResponse>> Handle(GetTripByRouteIdAndDateQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetTripByRouteIdAndDate(request.RouteId, request.date);
    }
}
