﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Group.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.GroupUser;

public class GroupUser
{
    public Guid GroupId { get; set; }

    public Guid UserId { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Group.Group Group { get; set; } = null!;

    public virtual User.User User { get; set; } = null!;

    private GroupUser() { }

    public GroupUser(
        Guid groupId,
        Guid userId,
        Guid? createBy,
        DateTime? createTime,
        Guid? updateBy,
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

    public static GroupUser Create(Guid groupId, Guid userId)
    {
        return new(groupId, userId, null, DateTime.UtcNow, null, DateTime.UtcNow);
    }
}
