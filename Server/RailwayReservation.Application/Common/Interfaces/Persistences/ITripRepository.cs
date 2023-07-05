using RailwayReservation.Application.Trip.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ITripRepository : IGenericRepository<Domain.Trip.Trip, TripResponse>
    {
        
    }
}