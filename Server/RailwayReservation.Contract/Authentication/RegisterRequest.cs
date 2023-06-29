using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Contract.Authentication;

public record RegisterRequest (
    string FullName,
    DateTime Dob,
    string Genger,
    string Email,
    string? PhoneNo,
    string Password,
    string Address
    );
