using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Train
{
    public int TrainId { get; set; }

    public string TrainName { get; set; } = null!;

    public string? Description { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();
}
