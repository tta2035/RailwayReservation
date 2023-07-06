using RailwayReservation.Application.BookingTicket.DTO;
using RailwayReservation.Application.Ticket.DTO;
using RailwayReservation.Domain.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ITicketRepository : IGenericRepository<Domain.Ticket.Ticket, TicketResponse>
    {
        Task<List<TicketResponse>> GetByBooking(Guid bookingId);
        Task<List<Domain.Ticket.Ticket>> AutoCreateWhenCreateTrip(Guid tripId);
    }
}