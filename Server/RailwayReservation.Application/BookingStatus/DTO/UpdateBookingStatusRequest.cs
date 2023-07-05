using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingStatus.DTO
{
    public class UpdateBookingStatusRequest
    {
        public Guid Id { get; set; }

        public Guid BookingId { get; set; }

        public string Status { get; set; }

        public DateTime StatusTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Description { get; set; }

        public UpdateBookingStatusRequest(
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
