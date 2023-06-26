using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Refund
{
    public int RefundId { get; set; }

    public int BookingId { get; set; }

    public decimal RefundAmount { get; set; }

    public int Status { get; set; }

    public DateTime RefundTime { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
