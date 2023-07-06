using MediatR;
using RailwayReservation.Application.Coach.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.Handler
{
    public class DeleteCoachHandler : IRequestHandler<DeleteCoachCommand, int>
    {
        private readonly ICoachRepository _repo;

        public DeleteCoachHandler(ICoachRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeleteCoachCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(request.Id);
        }
    }
}