using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Refund.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Refund;

public sealed class Refund// : AggregateRoot<RefundId, Guid>
{
    public Guid Id { get; set; }

    public Guid BookingId { get; set; }

    public decimal RefundAmount { get; set; }

    public int Status { get; set; }

    public DateTime? RefundTime { get; set; }

    public string? Description { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public Booking.Booking Booking { get; set; } = null!;


    public Refund(
        Guid refundId,
        Guid bookingId,
        decimal refundAmount,
        int status,
        DateTime? refundTime,
        string? description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        // RefundId = refundId;
        BookingId = bookingId;
        RefundAmount = refundAmount;
        Status = status;
        RefundTime = refundTime;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    public Refund()
    {
    }

    private static Refund Create(
        Guid bookingId,
        decimal refundAmount,
        int status,
        DateTime? refundTime,
        string? description
    )
    {
        return new(
            new Guid(),
            bookingId,
            refundAmount,
            status,
            refundTime,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
