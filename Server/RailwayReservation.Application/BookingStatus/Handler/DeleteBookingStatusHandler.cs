using MediatR;
using RailwayReservation.Application.BookingStatus.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingStatus.Handler
{
    public class DeleteBookingStatusHandler : IRequestHandler<DeleteBookingStatusCommand, int>
    {
        private readonly IBookingStatusRepository _repo;

        public DeleteBookingStatusHandler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeleteBookingStatusCommand request, CancellationToken cancellationToken)
        {
            var item = _repo.getById(request.Id);
            if(item is null) return default;
            return await _repo.Delete(request.Id);
        }
    }
}