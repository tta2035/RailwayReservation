using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ISeatRepository : IGenericRepository<Domain.Seat.Seat, Domain.Seat.Seat>
    {
        
    }
}