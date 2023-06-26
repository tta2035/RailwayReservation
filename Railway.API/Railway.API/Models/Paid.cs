using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Paid
{
    public int PaidId { get; set; }

    public int BookingId { get; set; }

    public decimal PaidAmount { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
