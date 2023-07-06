using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.SeatType.DTO
{
    public class SeatTypeResponse
    {
        public Guid Id { get; set; }

        public string SeatTypeName { get; set; }

        public double RaitoFare { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public SeatTypeResponse(Guid id, string seatTypeName, double raitoFare, string? description, Guid? createBy, DateTime createTime, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            SeatTypeName = seatTypeName;
            RaitoFare = raitoFare;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }

        public SeatTypeResponse()
        {
        }
    }
}