using RailwayReservation.Application.BookingStatus.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IBookingStatusRepository : IGenericRepository<Domain.BookingStatus.BookingStatus, BookingStatusResponse>
    {
        Task<List<BookingStatusResponse>> GetByBookingId(Guid id);
    }
}