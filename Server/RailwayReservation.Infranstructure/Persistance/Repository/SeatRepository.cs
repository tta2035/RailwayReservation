using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Seat.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class SeatRepository : GenericRepository<Domain.Seat.Seat, SeatResponse>, ISeatRepository
    {
        public SeatRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}