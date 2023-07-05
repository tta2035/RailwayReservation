using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Trip.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class TripRepository
        : GenericRepository<Domain.Trip.Trip, TripResponse>,
            ITripRepository
    {
        public TripRepository(RailwayReservationDbContext context)
            : base(context) { }
    }
}
