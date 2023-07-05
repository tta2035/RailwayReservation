using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Seat.DTO
{
    public class SeatResponse
    {
        public Guid Id { get; set; }

        public Guid CoachId { get; set; }
        public string CoachNo { get; set; }
        public string TrainName { get; set; }

        public Guid SeatTypeId { get; set; }

        public string SeatNo { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public SeatResponse(
            Guid id,
            Guid coachId,
            string coachNo,
            string trainName,
            Guid seatTypeId,
            string seatNo,
            string? description,
            Guid? createBy,
            DateTime createTime,
            Guid? updateBy,
            DateTime? updateTime
        )
        {
            Id = id;
            CoachId = coachId;
            CoachNo = coachNo;
            TrainName = trainName;
            SeatTypeId = seatTypeId;
            SeatNo = seatNo;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}
