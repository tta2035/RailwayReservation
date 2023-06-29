using System;
using System.Collections.Generic;

namespace RailwayReservation.Api.Models;

public partial class GroupUser
{
    public int GroupId { get; set; }

    public int UserId { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
