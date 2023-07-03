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
    public class GetStationByIdHandler : IRequestHandler<GetStationByIdQuery, StationResponse>
    {
        private readonly IStationRepository _stationRepository;

        public GetStationByIdHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public Task<StationResponse> Handle(
            GetStationByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var stationFound = _stationRepository.GetResponseById(request.Id);
            if(request is null) return default;
            return stationFound;
        }
    }
}
