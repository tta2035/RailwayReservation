using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Station.DTO
{
    public class StationResponse
    {
        public Guid Id { get; set; }

        public string StationName { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public int RouteCount { get; set; } = 0;

        public StationResponse()
        {
        }

        public StationResponse(
            Guid id,
            string stationName,
            string? description,
            Guid? createBy,
            DateTime createTime,
            Guid? updateBy,
            DateTime? updateTime,
            int routeCount
        )
        {
            Id = id;
            StationName = stationName;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            RouteCount = routeCount;
        }

    }
}
