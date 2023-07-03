using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Train.DTO;
using RailwayReservation.Domain.Train;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class TrainRepository
        : GenericRepository<Domain.Train.Train, TrainResponse>,
            ITrainRepository
    {
        public TrainRepository(RailwayReservationDbContext context)
            : base(context) { }

        public override Task<List<TrainResponse>> GetAll()
        {
            return base.GetAll();
        }

        public Task<TrainResponse> GetTrainResponseById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
