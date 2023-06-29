using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(
        string FullName,
        DateTime Dob,
        string Genger,
        string Email,
        string PhoneNo,
        string Password,
        string Address
        );

    AuthenticationResult Login(string Email, string Password);
}
