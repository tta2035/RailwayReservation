using MediatR;
using RailwayReservation.Application.BookingStatus.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingStatus.Handler
{
    public class CreateBookingStatusHandler : IRequestHandler<CreateBookingStatusCommand, Domain.BookingStatus.BookingStatus>
    {
        private readonly IBookingStatusRepository _repo;

        public CreateBookingStatusHandler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public Task<Domain.BookingStatus.BookingStatus> Handle(CreateBookingStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}