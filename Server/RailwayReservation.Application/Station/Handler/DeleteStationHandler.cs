using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Station.Commands;

namespace RailwayReservation.Application.Station.Handler
{
    public class DeleteStationHandler : IRequestHandler<DeleteStationCommand, int>
    {
        private readonly IStationRepository _stationRepository;

        public DeleteStationHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<int> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            var station = await _stationRepository.getById(request.Id);
            if(station is null) return default;
            return await _stationRepository.Delete(request.Id);
        }
    }
}