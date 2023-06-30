using RailwayReservation.Domain.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences;

public interface IPassengerRepository
{
    Passenger? GetUserByPhoneNo(string phoneNo);
    Passenger? GetUserByEmail(string email);
    void Add(Passenger passenger);
}
