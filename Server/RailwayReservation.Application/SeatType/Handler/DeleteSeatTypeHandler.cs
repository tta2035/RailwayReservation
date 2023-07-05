using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.SeatType.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.SeatType.Handler
{
    public class DeleteSeatTypeHandler : IRequestHandler<DeleteSeatTypeCommand, int>
    {
        private ISeatTypeRepository _repo;

        public DeleteSeatTypeHandler(ISeatTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeleteSeatTypeCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);
            if (item is null) return default;
            return await _repo.Delete(request.Id);
        }
    }
}