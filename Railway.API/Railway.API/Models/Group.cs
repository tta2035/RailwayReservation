using System;
using System.Collections.Generic;

namespace Railway.API.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public int? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<GroupFunction> GroupFunctions { get; set; } = new List<GroupFunction>();

    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
}
