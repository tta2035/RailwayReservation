using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Booking.DTO;

namespace RailwayReservation.Application.Booking.Queries
{
    public class GetBookingByIdQuery : IRequest<BookingResponse>
    {
        public Guid Id { get; set; }
    }
}