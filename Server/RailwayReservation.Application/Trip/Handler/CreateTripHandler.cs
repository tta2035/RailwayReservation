using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Trip.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Handler
{
    public class CreateTripHandler : IRequestHandler<CreateTripCommand, Domain.Trip.Trip>
    {
        private readonly ITripRepository _repo;

        public CreateTripHandler(ITripRepository repo)
        {
            _repo = repo;
        }

        public Task<Domain.Trip.Trip> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}