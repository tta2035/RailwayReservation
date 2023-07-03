using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Train.DTO;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface ITrainRepository : IGenericRepository<Domain.Train.Train, TrainResponse>
    {
        Task<TrainResponse> GetTrainResponseById(Guid Id);
    }
}