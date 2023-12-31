using RailwayReservation.Application.Seat.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ISeatRepository : IGenericRepository<Domain.Seat.Seat, SeatResponse>
    {
        Task<List<SeatResponse>> GetByCoach(Guid coachId);
    }
}