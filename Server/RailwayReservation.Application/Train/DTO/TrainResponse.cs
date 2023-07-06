using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Coach.DTO;
using RailwayReservation.Domain.Coach;

namespace RailwayReservation.Application.Train.DTO
{
    public class TrainResponse
    {
        public TrainResponse() { }

        public Guid Id { get; set; }
        public string TrainName { get; set; } = null!;

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public int CoachQuantity { get; set; }
        public int SeatQuantity { get; set; }
        public List<CoachResponse> Coaches { get; set; } = new();

        public TrainResponse(
            Guid id,
            string trainName,
            string? description,
            Guid? createBy,
            DateTime createTime,
            Guid? updateBy,
            DateTime? updateTime,
            int coachQuantity,
            int seatQuantity
        )
        {
            Id = id;
            TrainName = trainName;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            CoachQuantity = coachQuantity;
            SeatQuantity = seatQuantity;
        }
    }
}
