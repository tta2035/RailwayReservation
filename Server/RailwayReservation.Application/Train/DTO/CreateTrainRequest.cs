using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Train.DTO
{
    public class CreateTrainRequest
    {
        public string TrainName { get; set; }

        public string? Description { get; set; } = null!;

        public Guid? CreateBy { get; set; } = null!;

        public DateTime CreateTime { get; set; }

        public CreateTrainRequest(
            string trainName,
            string? description,
            Guid? createBy,
            DateTime createTime
        )
        {
            TrainName = trainName;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}
