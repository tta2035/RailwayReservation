using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IBookingStatusRepository : IGenericRepository<Domain.BookingStatus.BookingStatus, Domain.BookingStatus.BookingStatus>
    {
        Task<Domain.BookingStatus.BookingStatus> getBookingStatusResponse(Guid id);
    }
}