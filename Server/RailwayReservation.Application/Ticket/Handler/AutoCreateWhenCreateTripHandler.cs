using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Application.Ticket.Commands;

namespace RailwayReservation.Application.Ticket.Handler;

public class AutoCreateWhenCreateTripHandler : IRequestHandler<AutoCreateWhenCreateTripCommand, List<Domain.Ticket.Ticket>>
{
    private readonly ITicketRepository _repo;

    public AutoCreateWhenCreateTripHandler(ITicketRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Domain.Ticket.Ticket>> Handle(AutoCreateWhenCreateTripCommand request, CancellationToken cancellationToken)
    {
        return await _repo.AutoCreateWhenCreateTrip(request.TripId);
    }
}
