using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class TicketRepository
        : GenericRepository<Domain.Ticket.Ticket, Domain.Ticket.Ticket>,
            ITicketRepository
    {
        public TicketRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}
