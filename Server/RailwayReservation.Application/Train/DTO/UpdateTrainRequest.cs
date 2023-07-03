using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Train.DTO
{
    public class UpdateTrainRequest
    {
        public Guid Id { get; set; }
        public string TrainName { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateTrainRequest(
            Guid id,
            string trainName,
            string? description,
            Guid? createBy,
            DateTime createTime,
            Guid? updateBy,
            DateTime? updateTime
        )
        {
            Id = id;
            TrainName = trainName;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}
