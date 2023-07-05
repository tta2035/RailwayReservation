using MediatR;
using RailwayReservation.Application.Trip.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Queries
{
    public class GetTripByIdQuery : IRequest<TripResponse>
    {
        public Guid Id { get; set; }
    }
}