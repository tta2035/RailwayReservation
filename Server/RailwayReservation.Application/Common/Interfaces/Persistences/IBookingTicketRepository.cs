using RailwayReservation.Application.BookingTicket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IBookingTicketRepository
        : IGenericRepository<
            Domain.BookingTicket.BookingTicket,
            BookingTicketResponse
        > {
        Task<List<BookingTicketResponse>> GetByBookingId(Guid bookingId);
        Task<List<BookingTicketResponse>> GetByTicketId(Guid ticketId);
        Task<Domain.BookingTicket.BookingTicket> GetBy2Id(Guid bookingId, Guid ticketId);
        Task<int> DeleteBy2Id(Guid bookingId, Guid ticketId);
    }
}
