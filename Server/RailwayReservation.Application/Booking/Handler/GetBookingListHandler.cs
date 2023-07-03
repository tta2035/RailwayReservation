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
    public class GetBookingListHandler : IRequestHandler<GetBookingListQuery, List<BookingResponse>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingListHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<List<BookingResponse>> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetAll();
        }
    }
}