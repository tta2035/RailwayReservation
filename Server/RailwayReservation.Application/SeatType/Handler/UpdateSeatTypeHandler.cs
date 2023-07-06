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
    public class UpdateSeatTypeHandler : IRequestHandler<UpdateSeatTypeCommand, int>
    {
        private ISeatTypeRepository _repo;

        public UpdateSeatTypeHandler(ISeatTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UpdateSeatTypeCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);

            item.SeatTypeName = request.SeatTypeName;
            item.RaitoFare  = request.RaitoFare;
            item.Description = request.Description;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;
            return await _repo.Update(item);
        }
    }
}