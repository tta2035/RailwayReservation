using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Contract.Authentication;

public record AuthenticationResponse (
    Guid PassengerId,
    string FullName,
    DateTime Dob,
    string Genger,
    string Email,
    string? PhoneNo,
    string Password,
    string Address,
    string? Token,
    string? Description,
    int? CreateBy,
    DateTime CreateTime,
    int? UpdateBy,
    DateTime? UpdateTime
    );
