using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Function
{
    public int FunctionId { get; set; }

    public string FunctionName { get; set; } = null!;

    public int? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<GroupFunction> GroupFunctions { get; set; } = new List<GroupFunction>();
}
