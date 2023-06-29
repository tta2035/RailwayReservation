using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Paid.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Paid;

public sealed class Paid : AggregateRoot<PaidId, Guid>
{
    // public PaidId PaidId { get; set; }

    public BookingId BookingId { get; set; }

    public decimal PaidAmount { get; set; }

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public Booking.Booking Booking { get; set; } = null!;

    private Paid() { }

    public Paid(
        PaidId paidId,
        BookingId bookingId,
        decimal paidAmount,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(paidId)
    {
        // PaidId = paidId;
        BookingId = bookingId;
        PaidAmount = paidAmount;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Paid Create(BookingId bookingId, decimal paidAmount, string? description)
    {
        return new(
            PaidId.CreateUnique(),
            bookingId,
            paidAmount,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
