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
    public class Trip// : AggregateRoot<TripId, Guid>
    {
        public Guid Id { get; set; }

        public Guid TrainId { get; set; }

        public Guid RouteId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public string Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Route.Route Route { get; set; }

        public virtual ICollection<Ticket.Ticket> Tickets { get; set; } = new List<Ticket.Ticket>();

        public virtual Train.Train Train { get; set; }

        private Trip() { }

        public Trip(
            Guid id,
            Guid trainId,
            Guid routeId,
            DateTime departureTime,
            DateTime arriveTime,
            string description,
            Guid? createBy,
            DateTime? createTime,
            Guid? updateBy,
            DateTime? updateTime
        )
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

        public static Trip Create(
            Guid trainId,
            Guid routeId,
            DateTime departureTime,
            DateTime arriveTime,
            string description,
            Guid? updateBy
        )
        {
            return new(
                new Guid(),
                trainId,
                routeId,
                departureTime,
                arriveTime,
                description,
                updateBy,
                DateTime.UtcNow,
                null,
                DateTime.UtcNow
            );
        }
    }
}
