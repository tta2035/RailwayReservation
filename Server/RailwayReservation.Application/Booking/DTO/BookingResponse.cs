using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.BookingStatus.DTO;
using RailwayReservation.Application.Ticket.DTO;
using RailwayReservation.Domain.BookingStatus;
using RailwayReservation.Domain.BookingTicket;

namespace RailwayReservation.Application.Booking.DTO
{
    public class BookingResponse
    {
        public Guid Id { get; set; }

        public Guid PassengerId { get; set; }
        public string PassengerName { get; set; }

        public decimal TotalFare { get; set; }

        public decimal TotalPayment { get; set; }

        public string Status { get; set; }

        public DateTime PaymentTerm { get; set; }

        public Guid? PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }

        public DateTime? CancellationTime { get; set; }

        public decimal? CancellationFee { get; set; }

        public string? CancellationReason { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime BookingTime { get; set; }

        public Guid? UserId { get; set; }

        public decimal? PaidAmount { get; set; }

        public DateTime? PaidTime { get; set; }

        public decimal? RefundAmount { get; set; }

        public DateTime? RefundTime { get; set; }

        public List<TicketResponse> ListTicket { get; set; } = new();
        public List<BookingStatusResponse> ListBookingStatus { get; set; } = new();
        public BookingResponse() {}

        public BookingResponse(
            Guid id,
            Guid passengerId,
            string passengerName,
            decimal totalFare,
            decimal totalPayment,
            string status,
            DateTime paymentTerm,
            Guid? paymentMethodId,
            string paymentMethodName,
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
            Id = id;
            PassengerId = passengerId;
            PassengerName = passengerName;
            TotalFare = totalFare;
            TotalPayment = totalPayment;
            Status = status;
            PaymentTerm = paymentTerm;
            PaymentMethodId = paymentMethodId;
            PaymentMethodName = paymentMethodName;
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
