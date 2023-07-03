using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.BookingStatus;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class BookingStatusRepository : GenericRepository<BookingStatus, BookingStatus>, IBookingStatusRepository
    {
        public BookingStatusRepository(RailwayReservationDbContext context) : base(context)
        {
        }

        public Task<BookingStatus> getBookingStatusResponse(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}