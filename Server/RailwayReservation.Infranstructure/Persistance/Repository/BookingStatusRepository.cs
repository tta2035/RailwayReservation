using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.BookingStatus.DTO;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.BookingStatus;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class BookingStatusRepository
        : GenericRepository<BookingStatus, BookingStatusResponse>,
            IBookingStatusRepository
    {
        public BookingStatusRepository(RailwayReservationDbContext context)
            : base(context) { }

        public override async Task<List<BookingStatusResponse>> GetAll()
        {
            var result = await (from bs in table
                          select new BookingStatusResponse()
                          {
                              Id = bs.Id,
                              BookingId = bs.BookingId,
                              Status = bs.Status,
                              StatusTime = bs.StatusTime,
                              Description = bs.Description,
                          }).ToListAsync();
            return result;
        }

        public async Task<List<BookingStatusResponse>> GetByBookingId(Guid id)
        {
            var result = await GetAll();
            return result.Where(e => e.BookingId == id).ToList();
        }

        public async override Task<BookingStatusResponse?> GetResponseById(Guid id)
        {
            var result = await GetAll();
            return result.Where(e => e.Id == id).Single();
        }
    }
}
