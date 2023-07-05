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
        > { }
}
