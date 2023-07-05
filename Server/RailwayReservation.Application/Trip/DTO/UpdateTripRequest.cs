using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.DTO
{
    public class UpdateTripRequest
    {
        public Guid Id { get; set; }

        public Guid TrainId { get; set; }

        public Guid RouteId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public string Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateTripRequest(Guid id, Guid trainId, Guid routeId, DateTime departureTime, DateTime arriveTime, string description, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            TrainId = trainId;
            RouteId = routeId;
            DepartureTime = departureTime;
            ArriveTime = arriveTime;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}