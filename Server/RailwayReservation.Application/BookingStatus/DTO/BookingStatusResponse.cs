using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingStatus.DTO
{
    public class BookingStatusResponse
    {
        public Guid Id { get; set; }

        public Guid BookingId { get; set; }

        public string Status { get; set; }

        public DateTime StatusTime { get; set; }

        public string Description { get; set; }

        public BookingStatusResponse(
            Guid id,
            Guid bookingId,
            string status,
            DateTime statusTime,
            string description
        )
        {
            Id = id;
            BookingId = bookingId;
            Status = status;
            StatusTime = statusTime;
            Description = description;
        }
    }
}
