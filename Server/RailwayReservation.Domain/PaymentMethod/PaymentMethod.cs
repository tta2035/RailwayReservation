using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.PaymentMethod;

public sealed class PaymentMethod : AggregateRoot<PaymentMethodId, Guid>
{
    public PaymentMethodId Id { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<BankingPassenger.BankingPassenger> BankingPassengers { get; set; } =
        new List<BankingPassenger.BankingPassenger>();

    public ICollection<Booking.Booking> Bookings { get; set; } = new List<Booking.Booking>();

    private PaymentMethod() { }

    public PaymentMethod(
        PaymentMethodId paymentMethodId,
        string paymentMethodName,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(paymentMethodId)
    {
        // PaymentMethodId = paymentMethodId;
        PaymentMethodName = paymentMethodName;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static PaymentMethod Create(string paymentMethodName, string? description)
    {
        return new(
            PaymentMethodId.CreateUnique(),
            paymentMethodName,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
