using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Station.DTO
{
    public class StationUpdateRequest
    {
        public Guid Id { get; set; }
        public string StationName { get; set; }

        public string? Description { get; set; } = null!;
        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public StationUpdateRequest(
            Guid id,
            string stationName,
            string? description,
            Guid? updateBy,
            DateTime? updateTime
        )
        {
            Id = id;
            StationName = stationName;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}
