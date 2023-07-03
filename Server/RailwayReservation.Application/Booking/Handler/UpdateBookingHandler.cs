using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Booking.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Application.Booking.Handler
{
    public class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, int>
    {
        private readonly IBookingRepository _bookingRepository;

        public UpdateBookingHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var findBooking = _bookingRepository.getById(request.BookingId).Result;
            if(findBooking is null) return default;

            var newBooking = new Domain.Booking.Booking(
                request.BookingId,
                request.PassengerId,
                request.TotalFare,
                request.TotalPayment,
                request.Status,
                request.PaymentTerm,
                request.PaymentMethodId,
                request.CancellationTime,
                request.CancellationFee,
                request.CancellationReason,
                request.Description,
                request.CreateBy,
                request.CreateTime,
                request.UpdateBy,
                request.UpdateTime
            );
            return await _bookingRepository.Update(newBooking);
        }
    }
}