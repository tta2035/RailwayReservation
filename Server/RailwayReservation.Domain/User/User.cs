using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.User;

public sealed class User : AggregateRoot<UserId, Guid>
{
    public UserId Id { get; set; }
    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Token { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<GroupUser.GroupUser> GroupUsers { get; set; } =
        new List<GroupUser.GroupUser>();

    private User() { }

    public User(
        UserId userId,
        string userName,
        string email,
        string password,
        string firstName,
        string lastName,
        string? token,
        UserId? createBy,
        DateTime? createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(userId)
    {
        // UserId = userId;
        UserName = userName;
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Token = token;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static User Create(
        string userName,
        string email,
        string password,
        string firstName,
        string lastName,
        string? token
    )
    {
        return new(
            UserId.CreateUnique(),
            userName,
            email,
            password,
            firstName,
            lastName,
            token,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
