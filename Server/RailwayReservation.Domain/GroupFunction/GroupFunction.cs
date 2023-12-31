﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RailwayReservation.Domain.GroupFunction;

public class GroupFunction
{
    public Guid GroupId { get; set; }

    public Guid FunctionId { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    [JsonIgnore]
    public virtual Function.Function Function { get; set; } = null!;

    [JsonIgnore]
    public virtual Group.Group Group { get; set; } = null!;

    private GroupFunction() { }

    public GroupFunction(
        Guid groupId,
        Guid functionId,
        Guid? createBy,
        DateTime? createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        GroupId = groupId;
        FunctionId = functionId;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    public static GroupFunction Create(Guid groupId, Guid functionId, Guid? createBy)
    {
        return new(groupId, functionId, null, DateTime.UtcNow, null, DateTime.UtcNow);
    }
}
