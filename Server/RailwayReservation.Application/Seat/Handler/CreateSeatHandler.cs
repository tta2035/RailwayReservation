using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Seat.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Seat.Handler
{
    public class CreateSeatHandler : IRequestHandler<CreateSeatCommand, Domain.Seat.Seat>
    {
        private readonly ISeatRepository _repo;

        public CreateSeatHandler(ISeatRepository repo)
        {
            _repo = repo;
        }

        public async Task<Domain.Seat.Seat> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var item = Domain.Seat.Seat.Create(
                request.CoachId,
                request.SeatTypeId,
                request.SeatNo,
                request.Description,
                request.CreateBy
            );
            return await _repo.Insert(item);
        }
    }
}