using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Seat.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Seat.Handler
{
    public class DeleteSeatHandler : IRequestHandler<DeleteSeatCommand, int>
    {
        private readonly ISeatRepository _repo;

        public DeleteSeatHandler(ISeatRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}