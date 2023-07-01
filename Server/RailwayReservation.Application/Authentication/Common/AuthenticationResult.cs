using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Passenger;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Application.Authentication.Common;

public record AuthenticationResult
(
    Passenger passenger,
    string token
);
