using System;
using System.Collections.Generic;

namespace RailwayReservation.Api.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int PassengerId { get; set; }

    public decimal TotalFare { get; set; }

    public decimal TotalPayment { get; set; }

    public int Status { get; set; }

    public DateTime PaymentTerm { get; set; }

    public int DefaultPaymentMethod { get; set; }

    public int PassengerPaymentMethod { get; set; }

    public DateTime? CancellationTime { get; set; }

    public decimal? CancellationFee { get; set; }

    public string? CancellationReason { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<BookingTicket> BookingTickets { get; set; } = new List<BookingTicket>();

    public virtual PaymentMethod DefaultPaymentMethodNavigation { get; set; } = null!;

    public virtual ICollection<Paid> Paids { get; set; } = new List<Paid>();

    public virtual Passenger Passenger { get; set; } = null!;

    public virtual BankingPassenger PassengerPaymentMethodNavigation { get; set; } = null!;

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();
}
