using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class TripRepository
        : GenericRepository<Domain.Trip.Trip, Domain.Trip.Trip>,
            ITripRepository
    {
        public TripRepository(RailwayReservationDbContext context)
            : base(context) { }
    }
}
