using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Train.DTO;
using RailwayReservation.Application.Train.Queries;

namespace RailwayReservation.Application.Train.Handler
{
    public class GetTrainListHandler : IRequestHandler<GetTrainListQuery, List<TrainResponse>>
    {
        private readonly ITrainRepository _trainRepository;

        public GetTrainListHandler(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public Task<List<TrainResponse>> Handle(GetTrainListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}