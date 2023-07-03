using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Booking.Commands
{
    public class UpdateBookingCommand : IRequest<int>
    {
        public Guid BookingId { get; set; }

        public Guid PassengerId { get; set; }

        public decimal TotalFare { get; set; }

        public decimal TotalPayment { get; set; }

        public string Status { get; set; }

        public DateTime PaymentTerm { get; set; }

        public Guid? PaymentMethodId { get; set; } = null!;

        public DateTime? CancellationTime { get; set; } = null!;

        public decimal? CancellationFee { get; set; } = null!;

        public string? CancellationReason { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public Guid? CreateBy { get; set; } = null!;

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; } = null!;

        public DateTime? UpdateTime { get; set; } = null!;

        public DateTime BookingTime { get; set; }

        public Guid? UserId { get; set; } = null!;

        public decimal? PaidAmount { get; set; } = null!;

        public DateTime? PaidTime { get; set; } = null!;

        public decimal? RefundAmount { get; set; } = null!;

        public DateTime? RefundTime { get; set; } = null!;

        public UpdateBookingCommand(
            Guid bookingId,
            Guid passengerId,
            decimal totalFare,
            decimal totalPayment,
            string status,
            DateTime paymentTerm,
            Guid? paymentMethodId,
            DateTime? cancellationTime,
            decimal? cancellationFee,
            string? cancellationReason,
            string? description,
            Guid? createBy,
            DateTime createTime,
            Guid? updateBy,
            DateTime? updateTime,
            DateTime bookingTime,
            Guid? userId,
            decimal? paidAmount,
            DateTime? paidTime,
            decimal? refundAmount,
            DateTime? refundTime
        )
        {
            BookingId = bookingId;
            PassengerId = passengerId;
            TotalFare = totalFare;
            TotalPayment = totalPayment;
            Status = status;
            PaymentTerm = paymentTerm;
            PaymentMethodId = paymentMethodId;
            CancellationTime = cancellationTime;
            CancellationFee = cancellationFee;
            CancellationReason = cancellationReason;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            BookingTime = bookingTime;
            UserId = userId;
            PaidAmount = paidAmount;
            PaidTime = paidTime;
            RefundAmount = refundAmount;
            RefundTime = refundTime;
        }
    }
}
