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
    public class GetTrainByIdHandler : IRequestHandler<GetTrainByIdQuery, TrainResponse>
    {
        private readonly ITrainRepository _trainRepository;

        public GetTrainByIdHandler(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public Task<TrainResponse> Handle(GetTrainByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}