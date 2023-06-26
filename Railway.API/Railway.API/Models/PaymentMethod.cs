using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<BankingPassenger> BankingPassengers { get; set; } = new List<BankingPassenger>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
