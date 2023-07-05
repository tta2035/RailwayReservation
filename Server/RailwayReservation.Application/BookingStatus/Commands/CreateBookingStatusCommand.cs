using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.BookingStatus.Commands
{
    public class CreateBookingStatusCommand  : IRequest<Domain.BookingStatus.BookingStatus>
    {
        public Guid BookingId { get; set; }

        public string Status { get; set; }

        public DateTime StatusTime { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Description { get; set; }

        public CreateBookingStatusCommand(
            Guid bookingId,
            string status,
            DateTime statusTime,
            Guid? createBy,
            DateTime? createTime,
            string description
        )
        {
            BookingId = bookingId;
            Status = status;
            StatusTime = statusTime;
            CreateBy = createBy;
            CreateTime = createTime;
            Description = description;
        }
    }
}
