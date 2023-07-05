using MediatR;
using RailwayReservation.Application.Ticket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Queries
{
    public class GetTicketListQuery : IRequest<List<TicketResponse>>
    {
        
    }
}