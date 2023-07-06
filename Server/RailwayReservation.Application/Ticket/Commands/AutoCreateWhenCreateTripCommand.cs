using MediatR;

namespace RailwayReservation.Application.Ticket.Commands
{
    public class AutoCreateWhenCreateTripCommand : IRequest<List<Domain.Ticket.Ticket>>
    {
        public Guid TripId { get; set; }

        public AutoCreateWhenCreateTripCommand(Guid tripId)
        {
            TripId = tripId;
        }
    }
}