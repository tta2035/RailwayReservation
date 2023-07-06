using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.BookingTicket.DTO;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.Booking.ValueObjects;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class BookingTicketRepository : GenericRepository<Domain.BookingTicket.BookingTicket, BookingTicketResponse>, IBookingTicketRepository
    {
        public BookingTicketRepository(RailwayReservationDbContext context) : base(context)
        {
        }

        public async Task<int> DeleteBy2Id(Guid bookingId, Guid ticketId)
        {
            try
            {
                var item = await GetBy2Id(bookingId, ticketId);
                if (item is null) return default;
                table.Remove(item);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}");
            }
        }

        public override async Task<List<BookingTicketResponse>> GetAll()
        {
            var result = await (from bt in table
                          select new BookingTicketResponse()
                          {
                              BookingId = bt.BookingId,
                              TicketId = bt.TicketId,
                              Description = bt.Description,
                              CreateBy = bt.CreateBy,
                              CreateTime = bt.CreateTime,
                              UpdateBy = bt.UpdateBy,
                              UpdateTime = bt.UpdateTime,
                          }).ToListAsync();
            return result;
        }

        public async Task<Domain.BookingTicket.BookingTicket> GetBy2Id(Guid bookingId, Guid ticketId)
        {
            var item = await table.Where(e => e.BookingId == bookingId && e.TicketId == ticketId).FirstOrDefaultAsync();
            return item;
        }

        public async Task<List<BookingTicketResponse>> GetByBookingId(Guid bookingId)
        {
            var list = await GetAll();
            return list.Where(e => e.BookingId == bookingId).ToList();
        }

        public async Task<List<BookingTicketResponse>> GetByTicketId(Guid ticketId)
        {
            var list = await GetAll();
            return list.Where(e => e.TicketId == ticketId).ToList();
        }
    }
}