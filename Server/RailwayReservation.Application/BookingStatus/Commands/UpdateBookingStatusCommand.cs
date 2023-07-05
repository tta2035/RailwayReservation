using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.BookingStatus.Commands
{
    public class UpdateBookingStatusCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public Guid BookingId { get; set; }

        public string Status { get; set; }

        public DateTime StatusTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Description { get; set; }

        public UpdateBookingStatusCommand(
            Guid id,
            Guid bookingId,
            string status,
            DateTime statusTime,
            Guid? updateBy,
            DateTime? updateTime,
            string description
        )
        {
            Id = id;
            BookingId = bookingId;
            Status = status;
            StatusTime = statusTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            Description = description;
        }
    }
}
