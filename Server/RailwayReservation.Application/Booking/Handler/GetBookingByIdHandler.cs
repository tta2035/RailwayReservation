using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Booking.DTO;
using RailwayReservation.Application.Booking.Queries;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Application.Booking.Handler
{
    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, BookingResponse>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingByIdHandler (IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingResponse> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookingRepository.getBookingResponseById(request.Id);
            if(result is null) return null;
            return result;
        }
    }
}