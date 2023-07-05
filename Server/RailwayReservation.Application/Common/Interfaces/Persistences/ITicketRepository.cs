using RailwayReservation.Application.BookingTicket.DTO;
using RailwayReservation.Application.Ticket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ITicketRepository : IGenericRepository<Domain.Ticket.Ticket, TicketResponse>
    {
        
    }
}