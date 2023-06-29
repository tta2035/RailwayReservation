using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.BankingPassenger.ValueObjects;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Booking;

public class Booking : AggregateRoot<BookingId, Guid>
{
    // public BookingId BookingId { get; set; }

    public PassengerId PassengerId { get; set; }

    public decimal TotalFare { get; set; }

    public decimal TotalPayment { get; set; }

    public int Status { get; set; }

    public DateTime PaymentTerm { get; set; }

    public PaymentMethodId? DefaultPaymentMethod { get; set; } = null!;

    public BankingPassengerId? PassengerPaymentMethod { get; set; } = null!;

    public DateTime? CancellationTime { get; set; } = null!;

    public decimal? CancellationFee { get; set; } = null!;

    public string? CancellationReason { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public UserId? CreateBy { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; } = null!;

    public DateTime? UpdateTime { get; set; } = null!;

    public virtual ICollection<BookingTicket.BookingTicket> BookingTickets { get; set; } =
        new List<BookingTicket.BookingTicket>();

    public virtual PaymentMethod.PaymentMethod DefaultPaymentMethodNavigation { get; set; } = null!;

    public virtual ICollection<Paid.Paid> Paids { get; set; } = new List<Paid.Paid>();

    public virtual Passenger.Passenger Passenger { get; set; } = null!;

    public virtual BankingPassenger.BankingPassenger PassengerPaymentMethodNavigation { get; set; } =
        null!;

    public virtual ICollection<Refund.Refund> Refunds { get; set; } = new List<Refund.Refund>();

    private Booking() {}

    public Booking(
        BookingId bookingId,
        PassengerId passengerId,
        decimal totalFare,
        decimal totalPayment,
        int status,
        DateTime paymentTerm,
        PaymentMethodId defaultPaymentMethod,
        BankingPassengerId passengerPaymentMethod,
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
        // BookingId = bookingId;
        PassengerId = passengerId;
        TotalFare = totalFare;
        TotalPayment = totalPayment;
        Status = status;
        PaymentTerm = paymentTerm;
        DefaultPaymentMethod = defaultPaymentMethod;
        PassengerPaymentMethod = passengerPaymentMethod;
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
        int status,
        DateTime paymentTerm,
        PaymentMethodId defaultPaymentMethod,
        BankingPassengerId passengerPaymentMethod,
        DateTime? cancellationTime,
        decimal? cancellationFee,
        string? cancellationReason,
        string? description,
        UserId createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
    {
        return new(
            BookingId.CreateUnique(),
            passengerId,
            totalFare,
            totalPayment,
            status,
            paymentTerm,
            defaultPaymentMethod,
            passengerPaymentMethod,
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
