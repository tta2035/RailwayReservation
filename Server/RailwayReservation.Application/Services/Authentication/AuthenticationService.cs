using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces;

namespace RailwayReservation.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(
        string FullName,
        DateTime Dob,
        string Genger,
        string Email,
        string PhoneNo,
        string Password,
        string Address
        )
    {
        // check if user already exist


        // create user(generate ID)
        Guid ID = Guid.NewGuid();

        //create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(ID, FullName);

        return new AuthenticationResult(
            Guid.NewGuid(),
            FullName,
            Dob,
            Genger,
            Email,
            PhoneNo,
            Password,
            "",
            token,
            "",
            0,
            new DateTime(),
            0,
            new DateTime()
            );
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "",
            new DateTime(),
            "",
            Email,
            "",
            Password,
            "",
            "token",
            "",
            0,
            new DateTime(),
            0,
            new DateTime()
            );
    }
}
