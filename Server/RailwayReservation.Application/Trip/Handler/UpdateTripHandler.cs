using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Trip.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Handler
{
    public class UpdateTripHandler : IRequestHandler<UpdateTripCommand, int>
    {
        private readonly ITripRepository _repo;

        public UpdateTripHandler(ITripRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}