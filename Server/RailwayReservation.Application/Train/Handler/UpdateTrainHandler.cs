using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Train.Commands;

namespace RailwayReservation.Application.Train.Handler
{
    public class UpdateTrainHandler : IRequestHandler<UpdateTrainCommand, int>
    {
        private readonly ITrainRepository _trainRepository;

        public UpdateTrainHandler(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<int> Handle(UpdateTrainCommand request, CancellationToken cancellationToken)
        {
            var item = await _trainRepository.getById(request.Id);

            item.TrainName = request.TrainName;
            item.Description = request.Description; 
            item.UpdateBy   = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;
            return await _trainRepository.Update(item);
        }
    }
}