using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Station.DTO;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IStationRepository : IGenericRepository<Domain.Station.Station, StationResponse>
    {
        // Task<StationResponse> GetStationResponse(Guid Id);
    }
}