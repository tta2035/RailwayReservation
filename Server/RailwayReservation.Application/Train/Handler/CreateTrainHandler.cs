using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Train.Commands;

namespace RailwayReservation.Application.Train.Handler
{
    public class CreateTrainHandler : IRequestHandler<CreateTrainCommand, Domain.Train.Train>
    {
        private readonly ITrainRepository _trainRepository;

        public CreateTrainHandler(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<Domain.Train.Train> Handle(CreateTrainCommand request, CancellationToken cancellationToken)
        {
            var train = Domain.Train.Train.Create(
                request.TrainName,
                request.Description,
                request.CreateBy
            );
            return await _trainRepository.Insert(train); 
        }
    }
}