using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.DTO
{
    public class CreateTripRequest
    {

        public Guid TrainId { get; set; }

        public Guid RouteId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public string Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateTripRequest(Guid trainId, Guid routeId, DateTime departureTime, DateTime arriveTime, string description, Guid? createBy, DateTime? createTime)
        {
            TrainId = trainId;
            RouteId = routeId;
            DepartureTime = departureTime;
            ArriveTime = arriveTime;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}