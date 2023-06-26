using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class BankingPassenger
{
    public int BankingPassengerId { get; set; }

    public int PaymentMethodId { get; set; }

    public int PassengerId { get; set; }

    public string BankName { get; set; } = null!;

    public string BankAccountNumber { get; set; } = null!;

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Passenger Passenger { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
