using MediatR;
using RailwayReservation.Application.Ticket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Queries
{
    public class GetTicketByIdQuery : IRequest<TicketResponse>
    {
        public Guid Id { get; set; }
    }
}