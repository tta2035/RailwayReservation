using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.DTO
{
    public class CreateCoachRequest
    {

        public string CoachNo { get; set; } = null!;

        public Guid TrainId { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public CreateCoachRequest(string coachNo, Guid trainId, string? description, Guid? createBy, DateTime createTime)
        {
            CoachNo = coachNo;
            TrainId = trainId;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}