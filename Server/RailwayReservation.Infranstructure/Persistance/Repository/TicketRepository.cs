using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Ticket.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class TicketRepository
        : GenericRepository<Domain.Ticket.Ticket, TicketResponse>,
            ITicketRepository
    {
        public TicketRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}
