using RailwayReservation.Application.Common.DTOs;
using RailwayReservation.Domain.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<Passenger> Register(PassengerDto dto);
    Passenger login(LoginDto dto);
}
