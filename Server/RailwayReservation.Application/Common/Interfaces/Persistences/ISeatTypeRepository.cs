using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ISeatTypeRepository : IGenericRepository<Domain.SeatType.SeatType, Domain.SeatType.SeatType>
    {
        
    }
}