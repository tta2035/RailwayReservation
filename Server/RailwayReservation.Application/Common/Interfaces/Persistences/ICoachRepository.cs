using RailwayReservation.Application.Coach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ICoachRepository : IGenericRepository<Domain.Coach.Coach, CoachResponse>
    {
        Task<List<CoachResponse>> GetByTrainId(Guid trainId);
    }
}