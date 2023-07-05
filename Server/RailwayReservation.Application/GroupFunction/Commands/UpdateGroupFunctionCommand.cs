using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupFunction.Commands
{
    public class UpdateGroupFunctionCommand : IRequest<int>
    {
        public Guid GroupId { get; set; }

        public Guid FunctionId { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateGroupFunctionCommand(Guid groupId, Guid functionId, Guid? updateBy, DateTime? updateTime)
        {
            GroupId = groupId;
            FunctionId = functionId;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}