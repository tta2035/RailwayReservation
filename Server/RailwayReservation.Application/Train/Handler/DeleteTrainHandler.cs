using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Train.Commands;

namespace RailwayReservation.Application.Train.Handler
{
    public class DeleteTrainHandler : IRequestHandler<DeleteTrainCommand, int>
    {
        private readonly ITrainRepository _trainRepository;

        public DeleteTrainHandler(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<int> Handle(DeleteTrainCommand request, CancellationToken cancellationToken)
        {
            return await _trainRepository.Delete(request.Id);
        }
    }
}