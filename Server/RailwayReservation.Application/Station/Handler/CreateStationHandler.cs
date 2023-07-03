using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Station.Commands;

namespace RailwayReservation.Application.Station.Handler
{
    public class CreateStationHandler : IRequestHandler<CreateStationCommand, Domain.Station.Station>
    {
        private readonly IStationRepository _stationRepository;

        public CreateStationHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Domain.Station.Station> Handle(CreateStationCommand request, CancellationToken cancellationToken)
        {
            var station = Domain.Station.Station.Create(
                request.StationName,
                request.Description
            );
            return await _stationRepository.Insert(station);
        }
    }
}