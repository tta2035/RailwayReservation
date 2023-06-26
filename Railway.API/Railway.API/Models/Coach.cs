using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Coach
{
    public int CoachId { get; set; }

    public string CoachNo { get; set; } = null!;

    public int TrainId { get; set; }

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual Train Train { get; set; } = null!;
}
