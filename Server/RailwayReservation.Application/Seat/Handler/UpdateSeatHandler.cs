using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Seat.Commands;

namespace RailwayReservation.Application.Seat.Handler
{
    public class UpdateSeatHandler : IRequestHandler<UpdateSeatCommand, int>
    {
        private readonly ISeatRepository _repo;

        public UpdateSeatHandler(ISeatRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}