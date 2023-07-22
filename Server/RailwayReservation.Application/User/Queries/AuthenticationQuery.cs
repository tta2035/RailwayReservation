using MediatR;
using RailwayReservation.Application.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.User.Queries;

public class AuthenticationQuery : IRequest<UserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public AuthenticationQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public AuthenticationQuery()
    {
    }
}
