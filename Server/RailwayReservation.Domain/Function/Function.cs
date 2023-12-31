﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Function;

public sealed class Function // : AggregateRoot<FunctionId, Guid>
{
    public Guid Id { get; set; }

    public string FunctionName { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    [JsonIgnore]
    public ICollection<GroupFunction.GroupFunction> GroupFunctions { get; set; } =
        new List<GroupFunction.GroupFunction>();

    private Function() { }

    public Function(
        Guid functionId,
        string functionName,
        Guid? createBy,
        DateTime? createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        // FunctionId = functionId;
        FunctionName = functionName;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    public static Function Create(string functionName, Guid? createBy)
    {
        return new(new Guid(), functionName, createBy, DateTime.UtcNow, null, DateTime.UtcNow);
    }
}
