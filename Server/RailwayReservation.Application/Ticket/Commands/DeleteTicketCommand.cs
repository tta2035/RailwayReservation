using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Commands
{
    public class DeleteTicketCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}