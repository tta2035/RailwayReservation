using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Coach.DTO;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class CoachRepository : GenericRepository<Domain.Coach.Coach, CoachResponse>, ICoachRepository
    {
        public CoachRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}