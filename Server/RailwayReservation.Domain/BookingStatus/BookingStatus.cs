using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.BookingStatus.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.BookingStatus
{
    public class BookingStatus : AggregateRoot<BookingStatusId, Guid>
    {
        public BookingStatusId Id { get; set; }

        public BookingId BookingId { get; set; }

        public string Status { get; set; }

        public DateTime StatusTime { get; set; }

        public UserId? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public UserId? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Description { get; set; }

        public virtual Booking.Booking Booking { get; set; }

        private BookingStatus() { }

        public BookingStatus(
            BookingStatusId id,
            BookingId bookingId,
            string status,
            DateTime statusTime,
            UserId? createBy,
            DateTime? createTime,
            UserId? updateBy,
            DateTime? updateTime,
            string description
        )
            : base(id)
        {
            // Id = id;
            BookingId = bookingId;
            Status = status;
            StatusTime = statusTime;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            Description = description;
        }

        private static BookingStatus Create(
            BookingId bookingId,
            string status,
            DateTime statusTime,
            string description
        )
        {
            return new(
                BookingStatusId.CreateUnique(),
                bookingId,
                status,
                statusTime,
                null,
                DateTime.UtcNow,
                null,
                DateTime.UtcNow,
                description
            );
        }
    }
}
