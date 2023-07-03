using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Station.DTO
{
    public class StationCreateRequest
    {
        public string StationName { get; set; }

        public string? Description { get; set; } = null!;

        public StationCreateRequest(string stationName, string? description)
        {
            StationName = stationName;
            Description = description;
        }
    }
}