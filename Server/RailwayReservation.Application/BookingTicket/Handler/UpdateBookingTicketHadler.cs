using MediatR;
using RailwayReservation.Application.BookingTicket.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Handler
{
    public class UpdateBookingTicketHadler : IRequestHandler<UpdateBookingTicketCommand, int>
    {
        private readonly IBookingTicketRepository _repo;

        public UpdateBookingTicketHadler(IBookingTicketRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateBookingTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}