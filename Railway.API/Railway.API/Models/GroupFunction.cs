using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class GroupFunction
{
    public int GroupId { get; set; }

    public int FunctionId { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Function Function { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;
}
