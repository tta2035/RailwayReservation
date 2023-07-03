using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Station.DTO;

namespace RailwayReservation.Application.Station.Queries
{
    public class GetStationListQuery : IRequest<List<StationResponse>>
    {
        
    }
}