using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.DTO
{
    public class TripResponse
    {
        public Guid Id { get; set; }

        public Guid TrainId { get; set; }
        public string TrainName { get; set; }

        public Guid RouteId { get; set; }
        public string RouteName { get; set; }
        public string DepartureStation { get; set; }
        public string DestinationStation { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public string Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public List<Domain.Ticket.Ticket> Tickets { get; set; } = new();


        public TripResponse(Guid id, Guid trainId, string trainName, Guid routeId, string routeName, string departureStation, string destinationStation, DateTime departureTime, DateTime arriveTime, string description, Guid? createBy, DateTime? createTime, Guid? updateBy, DateTime? updateTime, List<Domain.Ticket.Ticket> tickets)
        {
            Id = id;
            TrainId = trainId;
            TrainName = trainName;
            RouteId = routeId;
            RouteName = routeName;
            DepartureStation = departureStation;
            DestinationStation = destinationStation;
            DepartureTime = departureTime;
            ArriveTime = arriveTime;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            Tickets = tickets;
        }

        public TripResponse()
        {
        }
    }
}