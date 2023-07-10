using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Route.DTO
{
    public class RouteResponse
    {
        public Guid Id { get; set; }

        public string RouteName { get; set; } = null!;
        public Guid DepartureStationId { get; set; }

        public string DepartureStation { get; set; }
        public Guid DestinationStationId { get; set; }

        public string DestinationStation { get; set; }

        public decimal RouteFare { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public RouteResponse()
        {
        }

        public RouteResponse(
            Guid id,
            string routeName,
            Guid departureStationId,
            string departureStation,
            Guid destinationStationId,
            string destinationStation,
            decimal routeFare,
            string? description,
            Guid? createBy,
            DateTime createTime,
            Guid? updateBy,
            DateTime? updateTime
        )
        {
            Id = id;
            RouteName = routeName;
            DepartureStationId = departureStationId;
            DepartureStation = departureStation;
            DestinationStationId = destinationStationId;
            DestinationStation = destinationStation;
            RouteFare = routeFare;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }

        
    }
}
