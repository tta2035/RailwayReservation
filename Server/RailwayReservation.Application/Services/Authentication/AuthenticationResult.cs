using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Passenger;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Application.Services.Authentication;

public record AuthenticationResult
(
    //PassengerId PassengerId,
    //string FullName,
    //DateTime Dob,
    //string Genger,
    //string Email,
    //string? PhoneNo,
    //string Password,
    //string Address,
    //string? Token,
    //string? Description,
    //UserId? CreateBy,
    //DateTime CreateTime,
    //UserId? UpdateBy,
    //DateTime? UpdateTime
    Passenger passenger,
    string token
);
