using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Booking.DTO;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class BookingRepository : GenericRepository<Domain.Booking.Booking, BookingResponse>, IBookingRepository
    {
        public BookingRepository(RailwayReservationDbContext context) : base(context)
        {
        }

        public override Task<List<BookingResponse>> GetAll()
        {
            return base.GetAll();
        }

        public Task<BookingResponse> getBookingResponseById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}