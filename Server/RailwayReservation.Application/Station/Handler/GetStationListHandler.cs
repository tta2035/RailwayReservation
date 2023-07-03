using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Station.DTO;
using RailwayReservation.Application.Station.Queries;

namespace RailwayReservation.Application.Station.Handler
{
    public class GetStationListHandler : IRequestHandler<GetStationListQuery, List<StationResponse>>
    {
        private readonly IStationRepository _stationRepository;

        public GetStationListHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<List<StationResponse>> Handle(
            GetStationListQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _stationRepository.GetAll();
            return result;
        }
    }
}
