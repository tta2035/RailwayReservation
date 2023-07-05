using MediatR;
using RailwayReservation.Application.BookingTicket.DTO;
using RailwayReservation.Application.BookingTicket.Queries;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingTicket.Handler
{
    // khum can lam
    public class GetBookingTicketByIdHandler : IRequestHandler<GetBookingTicketByIdQuery, BookingTicketResponse>
    {
        private readonly IBookingTicketRepository _repo;

        public GetBookingTicketByIdHandler(IBookingTicketRepository repo)
        {
            _repo = repo;
        }

        public Task<BookingTicketResponse> Handle(GetBookingTicketByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}