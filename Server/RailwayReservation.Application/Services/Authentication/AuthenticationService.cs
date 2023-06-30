using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.Passenger;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.User.ValueObejcts;
using static System.Net.Mime.MediaTypeNames;

namespace RailwayReservation.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPassengerRepository _passengerRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IPassengerRepository passengerRepository
    ) {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passengerRepository = passengerRepository;
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
        // 1. Validate the user doesn't exist
        if(_passengerRepository.GetUserByEmail(Email) is not null)
        {
            throw new Exception("Email already exist");
        }

        if(_passengerRepository.GetUserByPhoneNo(PhoneNo) is not null)
        {
            throw new Exception("Phone Number already exist");
        }


        // create user(generate ID) & persist to DB
        Guid ID = Guid.NewGuid();
        Passenger passenger = Passenger.Create(
            FullName,
            Dob,
            Genger,
            Email,
            PhoneNo,
            Password,
            Address,
            "",
            "",
            ""
            );

        //create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(passenger);

        return new AuthenticationResult(
            passenger, token
            );
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        // 1. Validate the user doesn't exist
        if (_passengerRepository.GetUserByEmail(Email) is not Passenger passenger)
        {
            throw new Exception("Email không tồn tại");
        }

        // 2. Validate the password is correct
        if (Password != passenger.Password)
        {
            throw new Exception("Mật khẩu đăng nhập không chính xác");
        }

        // 3. Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(passenger);


        return new AuthenticationResult(
            passenger, token
            );
    }
}
