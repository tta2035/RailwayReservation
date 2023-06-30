using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.Trip.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.Trip
{
    public class Trip : AggregateRoot<TripId, Guid>
    {
        public TripId Id { get; set; }

        public TrainId TrainId { get; set; }

        public RouteId RouteId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public string Description { get; set; }

        public UserId? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public UserId? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Route.Route Route { get; set; }

        public virtual ICollection<Ticket.Ticket> Tickets { get; set; } = new List<Ticket.Ticket>();

        public virtual Train.Train Train { get; set; }

        private Trip() { }

        public Trip(
            TripId id,
            TrainId trainId,
            RouteId routeId,
            DateTime departureTime,
            DateTime arriveTime,
            string description,
            UserId? createBy,
            DateTime? createTime,
            UserId? updateBy,
            DateTime? updateTime
        )
            : base(id)
        {
            // Id = id;
            TrainId = trainId;
            RouteId = routeId;
            DepartureTime = departureTime;
            ArriveTime = arriveTime;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }

        private static Trip Create(
            TrainId trainId,
            RouteId routeId,
            DateTime departureTime,
            DateTime arriveTime,
            string description
        )
        {
            return new(
                TripId.CreateUnique(),
                trainId,
                routeId,
                departureTime,
                arriveTime,
                description,
                null,
                DateTime.UtcNow,
                null,
                DateTime.UtcNow
            );
        }
    }
}
