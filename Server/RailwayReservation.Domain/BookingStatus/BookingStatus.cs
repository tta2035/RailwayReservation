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
    public class BookingStatus// : AggregateRoot<BookingStatusId, Guid>
    {
        public Guid Id { get; set; }

        public Guid BookingId { get; set; }

        public string Status { get; set; }

        public DateTime StatusTime { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Description { get; set; }

        public virtual Booking.Booking Booking { get; set; }

        private BookingStatus() { }

        public BookingStatus(
            Guid id,
            Guid bookingId,
            string status,
            DateTime statusTime,
            Guid? createBy,
            DateTime? createTime,
            Guid? updateBy,
            DateTime? updateTime,
            string description
        )
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
            Guid bookingId,
            string status,
            DateTime statusTime,
            string description
        )
        {
            return new(
                new Guid(),
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
