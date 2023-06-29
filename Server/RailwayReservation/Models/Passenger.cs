using System;
using System.Collections.Generic;

namespace RailwayReservation.Api.Models;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Genger { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public string Password { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Image { get; set; }

    public string? Token { get; set; }

    public string? Description { get; set; }

    public int? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<BankingPassenger> BankingPassengers { get; set; } = new List<BankingPassenger>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
