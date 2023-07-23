using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.DTOs;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.Common.Errors;
using RailwayReservation.Domain.Passenger;
using static System.Net.Mime.MediaTypeNames;
using RailwayReservation.Application.Services.Authentication;

namespace RailwayReservation.Infranstructure.Persistance.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPassengerRepository _passengerRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IPassengerRepository passengerRepository
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passengerRepository = passengerRepository;
    }

    public async Task<Passenger> Register(PassengerDto dto)
    {
        if (dto == null) throw new Exception("Dữ liệu đăng ký không hợp lệ");
        if (await _passengerRepository.CheckEmailExistAsync(dto.Email)) throw new Exception("Email đã tồn tại");
        if (await _passengerRepository.CheckEmailPhoneNoAsync(dto.PhoneNo)) throw new Exception("SĐT đã tồn tại");

        var pass = _passengerRepository.CheckPasswordStrength(dto.Password);
        if (!string.IsNullOrEmpty(pass)) throw new Exception(pass);

        var passenger = Passenger.Create(
            dto.FullName,
            (DateTime)dto.Dob,
            dto.Genger,
            dto.Email,
            dto.PhoneNo,
            dto.Password,
            "",
            "",
            "",
            ""
            );
        passenger.Token = _jwtTokenGenerator.GenerateToken(passenger.Id, passenger.FullName);
        return passenger;
    }

    public Passenger login(LoginDto dto)
    {
        if (dto == null) throw new Exception("Dữ liệu đăng nhập không hợp lệ");
        var passenger = _passengerRepository.GetPassengerLogin(dto).Result;
        if (passenger is null)
        {
            throw new Exception("User Not Found");
        }
        passenger.Token = _jwtTokenGenerator.GenerateToken(passenger.Id, passenger.FullName);
        _passengerRepository.Save();
        return passenger;
    }
}
