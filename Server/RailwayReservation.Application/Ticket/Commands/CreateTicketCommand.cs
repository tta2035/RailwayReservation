using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.Commands
{
    public class CreateTicketCommand : IRequest<Domain.Ticket.Ticket>
    {
        public Guid TripId { get; set; }

        public Guid SeatId { get; set; }

        public decimal? Fare { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }
        public string Status { get; set; }

        public CreateTicketCommand(Guid tripId, Guid seatId, decimal? fare, string? description, Guid? createBy, DateTime createTime, string status)
        {
            TripId = tripId;
            SeatId = seatId;
            Fare = fare;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            Status = status;
        }
    }
}