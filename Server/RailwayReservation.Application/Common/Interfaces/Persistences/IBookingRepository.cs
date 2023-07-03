using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Booking.DTO;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IBookingRepository : IGenericRepository<Domain.Booking.Booking, BookingResponse>
    {
        Task<BookingResponse> getBookingResponseById(Guid id);
    }
}