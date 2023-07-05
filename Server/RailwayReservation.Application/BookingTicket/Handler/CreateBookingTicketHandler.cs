using MediatR;
using RailwayReservation.Application.BookingTicket.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Handler
{
    public class CreateBookingTicketHandler : IRequestHandler<CreateBookingTicketCommand, Domain.BookingTicket.BookingTicket>
    {
        private readonly IBookingTicketRepository _repo;

        public CreateBookingTicketHandler(IBookingTicketRepository repo)
        {
            _repo = repo;
        }

        public Task<Domain.BookingTicket.BookingTicket> Handle(CreateBookingTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}