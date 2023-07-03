using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Station.Commands;

namespace RailwayReservation.Application.Station.Handler
{
    public class UpdateStationHandler : IRequestHandler<UpdateStationCommand, int>
    {
        private readonly IStationRepository _stationRepository;

        public UpdateStationHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<int> Handle(UpdateStationCommand request, CancellationToken cancellationToken)
        {
            var findStation = _stationRepository.getById(request.Id).Result;
            if(findStation is null) return default;

            var newStation = Domain.Station.Station.Create(
                request.StationName,
                request.Description
            );
            return await _stationRepository.Update(newStation);
        }
    }
}