using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Station.Commands
{
    public class CreateStationCommand : IRequest<Domain.Station.Station>
    {
        public string StationName { get; set; }

        public string? Description { get; set; } = null!;

        public CreateStationCommand(string stationName, string? description)
        {
            StationName = stationName;
            Description = description;
        }
    }
}
