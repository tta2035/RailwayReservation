using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.DTO
{
    public class UpdateCoachRequest
    {
        public Guid Id { get; set; }

        public string CoachNo { get; set; } = null!;

        public Guid TrainId { get; set; }

        public string? Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateCoachRequest(Guid id, string coachNo, Guid trainId, string? description, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            CoachNo = coachNo;
            TrainId = trainId;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}