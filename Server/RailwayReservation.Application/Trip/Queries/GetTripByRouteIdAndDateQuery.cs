using MediatR;
using RailwayReservation.Application.Trip.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Queries;

public class GetTripByRouteIdAndDateQuery : IRequest<List<TripResponse>>
{
    public Guid RouteId { get; set; }
    public DateTime date { get; set; }
}
