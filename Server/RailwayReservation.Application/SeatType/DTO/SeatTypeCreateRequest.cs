using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.SeatType.DTO
{
    public class SeatTypeCreateRequest
    {

        public string SeatTypeName { get; set; }

        public double RaitoFare { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public SeatTypeCreateRequest(string seatTypeName, double raitoFare, string? description, Guid? createBy, DateTime? createTime)
        {
            SeatTypeName = seatTypeName;
            RaitoFare = raitoFare;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}