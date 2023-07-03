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

public class Passenger// : AggregateRoot<PassengerId, Guid>
{
    // [Key]
    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Genger { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public string Password { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Image { get; set; } = null!;

    public string? Token { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public Guid? CreateBy { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public Guid? UpdateBy { get; set; } = null!;

    public DateTime? UpdateTime { get; set; } = null!;

    public ICollection<Booking.Booking> Bookings { get; set; } = new List<Booking.Booking>();

    private Passenger() { }

    public Passenger(
        Guid passengerId,
        string fullName,
        DateTime dob,
        string genger,
        string email,
        string phoneNo,
        string password,
        string address,
        string image,
        string token,
        string description,
        Guid? createBy,
        DateTime createTime,
        Guid? updateBy,
        DateTime? updateTime
    )
    {
        Id = passengerId;
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

    public static Passenger Create(
        string fullName,
        DateTime dob,
        string genger,
        string email,
        string phoneNo,
        string password,
        string address,
        string image,
        string token,
        string description
    )
    {
        return new(
            new Guid(),
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
