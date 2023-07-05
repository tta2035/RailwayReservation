using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Train.Commands;
using RailwayReservation.Application.Trip.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Handler
{
    public class DeleteTripHandler : IRequestHandler<DeleteTripCommand, int>
    {
        private readonly ITripRepository _repo;

        public DeleteTripHandler(ITripRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}