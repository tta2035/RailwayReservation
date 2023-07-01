using RailwayReservation.Domain.Passenger;
using RailwayReservation.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Services.Authentication;

public record AuthenticationResult(Passenger User,
    string Token);