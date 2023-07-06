using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Group;

public sealed class Group // : AggregateRoot<GroupId, Guid>
{
    public Guid Id { get; set; }

    public string GroupName { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    [JsonIgnore]
    public ICollection<GroupFunction.GroupFunction> GroupFunctions { get; set; } =
        new List<GroupFunction.GroupFunction>();

    [JsonIgnore]
    public ICollection<GroupUser.GroupUser> GroupUsers { get; set; } =
        new List<GroupUser.GroupUser>();

    private Group() { }

    public Group(
        Guid groupId,
        string groupName,
        Guid? createBy,
        DateTime? createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        // GroupId = groupId;
        GroupName = groupName;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    public static Group Create(string groupName, Guid? createBy)
    {
        return new(new Guid(), groupName, createBy, DateTime.UtcNow, null, DateTime.UtcNow);
    }
}
