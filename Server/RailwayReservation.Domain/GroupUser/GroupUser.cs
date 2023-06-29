using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Group.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.GroupUser;

public class GroupUser
{
    public GroupId GroupId { get; set; }

    public UserId UserId { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Group.Group Group { get; set; } = null!;

    public virtual User.User User { get; set; } = null!;

    private GroupUser() { }

    public GroupUser(
        GroupId groupId,
        UserId userId,
        UserId? createBy,
        DateTime? createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
    {
        GroupId = groupId;
        UserId = userId;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static GroupUser Create(GroupId groupId, UserId userId)
    {
        return new(groupId, userId, null, DateTime.UtcNow, null, DateTime.UtcNow);
    }
}
