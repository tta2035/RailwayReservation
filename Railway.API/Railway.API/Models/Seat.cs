using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Seat
{
    public int SeatId { get; set; }

    public int CoachId { get; set; }

    public int SeatTypeId { get; set; }

    public string SeatNo { get; set; } = null!;

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Coach Coach { get; set; } = null!;

    public virtual SeatType SeatType { get; set; } = null!;
}
