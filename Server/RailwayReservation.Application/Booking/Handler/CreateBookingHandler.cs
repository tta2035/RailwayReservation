using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Booking.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Application.Booking.Handler
{
    public class CreateBookingHandler
        : IRequestHandler<CreateBookingCommand, Domain.Booking.Booking>
    {
        private readonly IBookingRepository _bookingRepositor;

        public CreateBookingHandler(IBookingRepository bookingRepositor)
        {
            _bookingRepositor = bookingRepositor;
        }

        public async Task<Domain.Booking.Booking> Handle(
            CreateBookingCommand request,
            CancellationToken cancellationToken
        )
        {
            var booking = Domain.Booking.Booking.Create(
                request.PassengerId,
                request.TotalFare,
                request.TotalPayment,
                request.Status,
                request.PaymentTerm,
                request.PaymentMethodId,
                null,
                0,
                null,
                request.Description
            );
            return await _bookingRepositor.Insert(booking);
        }
    }
}
