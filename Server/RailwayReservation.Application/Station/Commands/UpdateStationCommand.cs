using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Station.Commands
{
    public class UpdateStationCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public string StationName { get; set; }

        public string? Description { get; set; }
        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateStationCommand(
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
