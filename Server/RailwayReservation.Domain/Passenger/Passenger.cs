using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Passenger;

public sealed class Passenger : AggregateRoot<PassengerId, Guid>
{
    // [Key]
    // public PassengerId PassengerId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Genger { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public string Password { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Image { get; set; }

    public string? Token { get; set; }

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public ICollection<BankingPassenger.BankingPassenger> BankingPassengers { get; set; } =
        new List<BankingPassenger.BankingPassenger>();

    public ICollection<Booking.Booking> Bookings { get; set; } = new List<Booking.Booking>();

    private Passenger() { }

    private Passenger(
        PassengerId passengerId,
        string fullName,
        DateTime dob,
        string genger,
        string email,
        string? phoneNo,
        string password,
        string address,
        string? image,
        string? token,
        string? description,
        UserId? createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(passengerId)
    {
        // PassengerId = passengerId;
        FullName = fullName;
        Dob = dob;
        Genger = genger;
        Email = email;
        PhoneNo = phoneNo;
        Password = password;
        Address = address;
        Image = image;
        Token = token;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static Passenger Create(
        string fullName,
        DateTime dob,
        string genger,
        string email,
        string? phoneNo,
        string password,
        string address,
        string? image,
        string? token,
        string? description
    )
    {
        return new(
            PassengerId.CreateUnique(),
            fullName,
            dob,
            genger,
            email,
            phoneNo,
            password,
            address,
            image,
            token,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
