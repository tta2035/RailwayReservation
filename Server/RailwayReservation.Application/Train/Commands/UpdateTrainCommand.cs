using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Train.Commands
{
    public class UpdateTrainCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string TrainName { get; set; }

        public string? Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateTrainCommand(Guid id, string trainName, string? description, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            TrainName = trainName;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}