using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.BookingStatus.DTO;

namespace RailwayReservation.Application.BookingStatus.Queries
{
    public class GetBookingStatusByIdQuery : IRequest<BookingStatusResponse>
    {
        public Guid Id { get; set; }
    }
}