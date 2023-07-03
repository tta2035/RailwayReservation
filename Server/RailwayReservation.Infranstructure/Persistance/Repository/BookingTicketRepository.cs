using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class BookingTicketRepository : GenericRepository<Domain.BookingTicket.BookingTicket, Domain.BookingTicket.BookingTicket>, IBookingTicketRepository
    {
        public BookingTicketRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}