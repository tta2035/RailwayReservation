using System;
using System.Collections.Generic;

namespace RailwayReservation.Api.Models;

public partial class SeatType
{
    public int SeatTypeId { get; set; }

    public string SeatTypeName { get; set; } = null!;

    public decimal RaitoFare { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
