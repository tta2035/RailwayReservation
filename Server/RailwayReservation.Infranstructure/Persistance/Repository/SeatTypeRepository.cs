using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class SeatTypeRepository
        : GenericRepository<Domain.SeatType.SeatType, Domain.SeatType.SeatType>,
            ISeatTypeRepository
    {
        public SeatTypeRepository(RailwayReservationDbContext context)
            : base(context) { }
    }
}
