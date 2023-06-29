using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Function.ValueObjects;
using RailwayReservation.Domain.Group.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.GroupFunction;

public class GroupFunction
{
    public GroupId GroupId { get; set; }

    public FunctionId FunctionId { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Function.Function Function { get; set; } = null!;

    public virtual Group.Group Group { get; set; } = null!;

    private GroupFunction() { }

    public GroupFunction(
        GroupId groupId,
        FunctionId functionId,
        UserId? createBy,
        DateTime? createTime,
        UserId? updateBy,
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

    private static GroupFunction Create(GroupId groupId, FunctionId functionId)
    {
        return new(groupId, functionId, null, DateTime.UtcNow, null, DateTime.UtcNow);
    }
}
