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

        public Task<int> Handle(UpdateBookingStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}