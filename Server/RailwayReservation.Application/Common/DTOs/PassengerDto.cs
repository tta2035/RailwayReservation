using RailwayReservation.Domain.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.DTOs;

public class PassengerDto
{
    public string? FullName { get; set; }
    public DateTime? Dob { get; set; }
    public string? Genger { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public string? Password { get; set; }
    public string? Address { get; set; }
    public string? Token { get; set; }

    public PassengerDto(Passenger passenger)
    {
        FullName = passenger.FullName;
        Dob = passenger.Dob;
        Genger = passenger.Genger;
        Email = passenger.Email;
        PhoneNo = passenger.PhoneNo;
        Password = passenger.Password;
        Address = passenger.Address;
        Token = passenger.Token;
    }

    public PassengerDto(string? fullName, DateTime? dob, string? genger, string? email, string? phoneNo, string? password, string? address, string? token)
    {
        FullName = fullName;
        Dob = dob;
        Genger = genger;
        Email = email;
        PhoneNo = phoneNo;
        Password = password;
        Address = address;
        Token = token;
    }
}
