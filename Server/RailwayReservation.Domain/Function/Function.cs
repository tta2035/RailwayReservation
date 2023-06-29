using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Function.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Function;

public sealed class Function : AggregateRoot<FunctionId, Guid>
{
    // public FunctionId FunctionId { get; set; }

    public string FunctionName { get; set; } = null!;

    public UserId? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<GroupFunction.GroupFunction> GroupFunctions { get; set; } =
        new List<GroupFunction.GroupFunction>();

    private Function() { }

    public Function(
        FunctionId functionId,
        string functionName,
        UserId? createBy,
        DateTime? createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(functionId)
    {
        // FunctionId = functionId;
        FunctionName = functionName;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Function Create(string functionName)
    {
        return new(
            FunctionId.CreateUnique(),
            functionName,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
