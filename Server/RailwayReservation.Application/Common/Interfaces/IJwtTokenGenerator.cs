using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid PassengerID, string FullName);
}
