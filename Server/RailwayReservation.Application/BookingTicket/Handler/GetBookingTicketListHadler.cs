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
    public class GetBookingTicketListHadler : IRequestHandler<GetBookingTicketListQuery, List<BookingTicketResponse>>
    {
        private readonly IBookingTicketRepository _repo;

        public GetBookingTicketListHadler(IBookingTicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<BookingTicketResponse>> Handle(GetBookingTicketListQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}