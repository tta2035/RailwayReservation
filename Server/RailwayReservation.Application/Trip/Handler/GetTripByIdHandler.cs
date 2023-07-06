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
    public class GetTripByIdHandler : IRequestHandler<GetTripByIdQuery, TripResponse>
    {
        private readonly ITripRepository _repo;

        public GetTripByIdHandler(ITripRepository repo)
        {
            _repo = repo;
        }

        public async Task<TripResponse> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetResponseById(request.Id);
        }
    }
}