using MediatR;
using RailwayReservation.Application.BookingStatus.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingStatus.Handler
{
    public class UpdateBookingStatusHandler : IRequestHandler<UpdateBookingStatusCommand, int>
    {
        private readonly IBookingStatusRepository _repo;

        public UpdateBookingStatusHandler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UpdateBookingStatusCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);
            if(item is null) return default;
            
            item.Status = request.Status;
            item.StatusTime = request.StatusTime;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;
            item.Description = request.Description;

            return await _repo.Update(item);
        }
    }
}