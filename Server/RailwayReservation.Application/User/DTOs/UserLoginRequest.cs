using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.User.DTOs;

public class UserLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserLoginRequest()
    {
    }

    public UserLoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
