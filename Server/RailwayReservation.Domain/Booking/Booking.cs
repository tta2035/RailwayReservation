using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Booking;

public class Booking : AggregateRoot<BookingId, Guid>
{
    public BookingId Id { get; set; }

    public PassengerId PassengerId { get; set; }

    public decimal TotalFare { get; set; }

    public decimal TotalPayment { get; set; }

    public string Status { get; set; }

    public DateTime PaymentTerm { get; set; }

    public PaymentMethodId? PaymentMethodId { get; set; }

    public DateTime? CancellationTime { get; set; }

    public decimal? CancellationFee { get; set; }

    public string CancellationReason { get; set; }

    public string Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime BookingTime { get; set; }

    public Guid? UserId { get; set; }

    public decimal? PaidAmount { get; set; }

    public DateTime? PaidTime { get; set; }

    public decimal? RefundAmount { get; set; }

    public DateTime? RefundTime { get; set; }

    public virtual ICollection<BookingStatus.BookingStatus> BookingStatuses { get; set; } = new List<BookingStatus.BookingStatus>();

    public virtual ICollection<BookingTicket.BookingTicket> BookingTickets { get; set; } = new List<BookingTicket.BookingTicket>();

    public virtual Passenger.Passenger Passenger { get; set; }

    public virtual PaymentMethod.PaymentMethod PaymentMethod { get; set; }

    private Booking() {}

    public Booking(
        BookingId bookingId,
        PassengerId passengerId,
        decimal totalFare,
        decimal totalPayment,
        string status,
        DateTime paymentTerm,
        PaymentMethodId paymentMethodId,
        DateTime? cancellationTime,
        decimal? cancellationFee,
        string? cancellationReason,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(bookingId)
    {
        // Id = bookingId;
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
    }

    private static Booking Create(
        PassengerId passengerId,
        decimal totalFare,
        decimal totalPayment,
        string status,
        DateTime paymentTerm,
        PaymentMethodId paymentMethodId,
        DateTime? cancellationTime,
        decimal? cancellationFee,
        string? cancellationReason,
        string? description
    )
    {
        return new(
            BookingId.CreateUnique(),
            passengerId,
            totalFare,
            totalPayment,
            status,
            paymentTerm,
            paymentMethodId,
            cancellationTime,
            cancellationFee,
            cancellationReason,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
