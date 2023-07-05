using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Trip.DTO;
using RailwayReservation.Application.Trip.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Handler
{
    public class GetTripListHandler : IRequestHandler<GetTripListQuery, List<TripResponse>>
    {
        private readonly ITripRepository _repo;

        public GetTripListHandler(ITripRepository repo)
        {
            _repo = repo;
        }

        public Task<List<TripResponse>> Handle(GetTripListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}