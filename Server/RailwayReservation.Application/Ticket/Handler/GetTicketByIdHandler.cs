using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Ticket.DTO;
using RailwayReservation.Application.Ticket.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Handler
{
    public class GetTicketByIdHandler : IRequestHandler<GetTicketByIdQuery, TicketResponse>
    {
        private readonly ITicketRepository _repo;

        public GetTicketByIdHandler(ITicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<TicketResponse> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetResponseById(request.Id);
        }
    }
}