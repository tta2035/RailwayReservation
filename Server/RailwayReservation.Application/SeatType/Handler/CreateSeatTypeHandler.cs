using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.SeatType.Commands;
using RailwayReservation.Application.Station.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.SeatType.Handler
{
    public class CreateSeatTypeHandler : IRequestHandler<CreateSeatTypeCommand, Domain.SeatType.SeatType>
    {
        private ISeatTypeRepository _repo;

        public CreateSeatTypeHandler(ISeatTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<Domain.SeatType.SeatType> Handle(CreateSeatTypeCommand request, CancellationToken cancellationToken)
        {
            var item = Domain.SeatType.SeatType.Create(
                request.SeatTypeName,
                request.RaitoFare,
                request.Description,
                request.CreateBy
                );
            return await _repo.Insert(item);
        }
    }
}