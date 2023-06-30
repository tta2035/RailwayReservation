using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Persistance.Repository;

public class PassengerRepository : IPassengerRepository
{
    private static readonly List<Passenger> _passengers = new();
    public void Add(Passenger passenger)
    {
        _passengers.Add(passenger);
    }

    public Passenger? GetUserByEmail(string email)
    {
        return _passengers.SingleOrDefault(p => p.Email == email);
    }

    public Passenger? GetUserByPhoneNo(string phoneNo)
    {
        return _passengers.SingleOrDefault(p => p.PhoneNo == phoneNo);
    }
}
