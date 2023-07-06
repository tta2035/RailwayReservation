using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.PaymentMethod;

public sealed class PaymentMethod // : AggregateRoot<PaymentMethodId, Guid>
{
    public Guid Id { get; set; }

    public string PaymentMethodName { get; set; }

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    [JsonIgnore]
    public ICollection<Booking.Booking> Bookings { get; set; } = new List<Booking.Booking>();

    private PaymentMethod() { }

    public PaymentMethod(
        Guid paymentMethodId,
        string paymentMethodName,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        // PaymentMethodId = paymentMethodId;
        PaymentMethodName = paymentMethodName;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    public static PaymentMethod Create(
        string paymentMethodName,
        string? description,
        Guid? createBy
    )
    {
        return new(
            new Guid(),
            paymentMethodName,
            description,
            createBy,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
