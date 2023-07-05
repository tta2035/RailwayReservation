using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.SeatType.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class SeatTypeRepository
        : GenericRepository<Domain.SeatType.SeatType, SeatTypeResponse>,
            ISeatTypeRepository
    {
        public SeatTypeRepository(RailwayReservationDbContext context)
            : base(context) { }
    }
}
