using RailwayReservation.Application.Seat.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.DTO
{
    public class CoachResponse
    {
        public Guid Id { get; set; }

        public string CoachNo { get; set; } = null!;

        public Guid TrainId { get; set; }
        public string TrainName { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public List<SeatResponse> ListSeat { get; set; } = new();

        public CoachResponse(Guid id, string coachNo, Guid trainId, string trainName, string? description, Guid? createBy, DateTime createTime, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            CoachNo = coachNo;
            TrainId = trainId;
            TrainName = trainName;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}