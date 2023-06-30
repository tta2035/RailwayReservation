using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Group.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Group;

public sealed class Group : AggregateRoot<GroupId, Guid>
{
    public GroupId Id { get; set; }

    public string GroupName { get; set; } = null!;

    public UserId? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<GroupFunction.GroupFunction> GroupFunctions { get; set; } =
        new List<GroupFunction.GroupFunction>();

    public ICollection<GroupUser.GroupUser> GroupUsers { get; set; } =
        new List<GroupUser.GroupUser>();

    private Group() {}
    public Group(
        GroupId groupId,
        string groupName,
        UserId? createBy,
        DateTime? createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(groupId)
    {
        // GroupId = groupId;
        GroupName = groupName;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Group Create(string groupName)
    {
        return new(GroupId.CreateUnique(), groupName, null, DateTime.UtcNow, null, DateTime.UtcNow);
    }
}
