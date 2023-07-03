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

public class Booking //// : AggregateRoot<BookingId, Guid>
{
    public Guid Id { get; set; }

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

    public Guid? UserId { get; set; }

    public decimal? PaidAmount { get; set; } = null!;

    public DateTime? PaidTime { get; set; } = null!;

    public decimal? RefundAmount { get; set; } = null!;

    public DateTime? RefundTime { get; set; } = null!;

    public virtual ICollection<BookingStatus.BookingStatus> BookingStatuses { get; set; } = new List<BookingStatus.BookingStatus>();

    public virtual ICollection<BookingTicket.BookingTicket> BookingTickets { get; set; } = new List<BookingTicket.BookingTicket>();

    public virtual Passenger.Passenger Passenger { get; set; }

    public virtual PaymentMethod.PaymentMethod PaymentMethod { get; set; }

    private Booking() {}

    public Booking(
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
        DateTime? updateTime
    )
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

    public static Booking Create(
        Guid passengerId,
        decimal totalFare,
        decimal totalPayment,
        string status,
        DateTime paymentTerm,
        Guid paymentMethodId,
        DateTime? cancellationTime,
        decimal? cancellationFee,
        string? cancellationReason,
        string? description
    )
    {
        return new(
            new Guid(),
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
