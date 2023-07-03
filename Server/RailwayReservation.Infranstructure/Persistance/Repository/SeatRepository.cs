using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class SeatRepository : GenericRepository<Domain.Seat.Seat, Domain.Seat.Seat>, ISeatRepository
    {
        public SeatRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}