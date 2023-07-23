using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Passenger;

namespace RailwayReservation.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid id, string FullName);
}
