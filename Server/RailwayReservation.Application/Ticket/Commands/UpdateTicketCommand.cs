using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Commands
{
    public class UpdateTicketCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public Guid TripId { get; set; }

        public Guid SeatId { get; set; }

        public decimal? Fare { get; set; }

        public string? Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public string Status { get; set; }

        public UpdateTicketCommand(Guid id, Guid tripId, Guid seatId, decimal? fare, string? description, Guid? updateBy, DateTime? updateTime, string status)
        {
            Id = id;
            TripId = tripId;
            SeatId = seatId;
            Fare = fare;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            Status = status;
        }
    }
}