using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Booking.Commands
{
    public class CreateBookingCommand : IRequest<Domain.Booking.Booking>
    {
        public Guid BookingId { get; set; }
        public Guid PassengerId { get; set; }
        public Guid? UserId { get; set; }
        public decimal TotalFare { get; set; }
        public decimal TotalPayment { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public DateTime PaymentTerm { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime BookingTime { get; set; }

        public CreateBookingCommand(
            Guid passengerId,
            Guid? userId,
            decimal totalFare,
            decimal totalPayment,
            string status,
            string? description,
            DateTime paymentTerm,
            Guid paymentMethodId,
            Guid? createBy,
            DateTime createTime,
            DateTime bookingTime
        )
        {
            BookingId = new Guid();
            PassengerId = passengerId;
            UserId = userId;
            TotalFare = totalFare;
            TotalPayment = totalPayment;
            Status = status;
            Description = description;
            PaymentTerm = paymentTerm;
            PaymentMethodId = paymentMethodId;
            CreateBy = createBy;
            CreateTime = createTime;
            BookingTime = bookingTime;
        }
    }
}
