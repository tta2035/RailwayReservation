using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Booking.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Application.Booking.Handler
{
    public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, int>
    {
        private readonly IBookingRepository _bookingRepository;

        public DeleteBookingHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.getById(request.Id);
            if(booking is null) return default;
            return await _bookingRepository.Delete(booking.Id);
        }
    }
}
