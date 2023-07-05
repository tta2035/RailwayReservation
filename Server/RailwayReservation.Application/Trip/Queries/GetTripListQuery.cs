using MediatR;
using RailwayReservation.Application.Trip.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Queries
{
    public class GetTripListQuery : IRequest<List<TripResponse>>
    {
        
    }
}