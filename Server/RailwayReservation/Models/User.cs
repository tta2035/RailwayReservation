using System;
using System.Collections.Generic;

namespace RailwayReservation.Api.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Token { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
}
