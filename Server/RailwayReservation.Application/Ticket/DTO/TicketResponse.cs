using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Ticket.DTO
{
    public class TicketResponse
    {
        public Guid Id { get; set; }

        public Guid TripId { get; set; }

        public Guid SeatId { get; set; }
        public string SeatNo { get; set; }
        public string SeatTypeName { get; set; }
        public string TrainNo { get; set; }
        public Guid RouteId { get; set; }
        public string RouteName { get; set; }
        public string DepartureStation { get; set; } = "";
        public string DestinationStation { get; set; } = "";

        public DateTime DepartureTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public double? Fare { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public string Status { get; set; }

        public TicketResponse(Guid id, Guid tripId, Guid seatId, string seatNo, string seatTypeName, string trainNo, Guid routeId, string routeName, string departureStation, string destinationStation, DateTime departureTime, DateTime arriveTime, double? fare, string? description, Guid? createBy, DateTime createTime, Guid? updateBy, DateTime? updateTime, string status)
        {
            Id = id;
            TripId = tripId;
            SeatId = seatId;
            SeatNo = seatNo;
            SeatTypeName = seatTypeName;
            TrainNo = trainNo;
            RouteId = routeId;
            RouteName = routeName;
            DepartureStation = departureStation;
            DestinationStation = destinationStation;
            DepartureTime = departureTime;
            ArriveTime = arriveTime;
            Fare = fare;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            Status = status;
        }

        public TicketResponse()
        {
        }
    }
}