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

        public async Task<int> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);

            item.CoachId = request.CoachId;
            item.SeatTypeId = request.SeatTypeId;
            item.SeatNo = request.SeatNo;
            item.Description = request.Description;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;

            return await _repo.Update(item);
        }
    }
}