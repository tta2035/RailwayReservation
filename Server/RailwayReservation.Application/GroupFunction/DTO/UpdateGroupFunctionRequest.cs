using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupFunction.DTO
{
    public class UpdateGroupFunctionRequest
    {
        public Guid GroupId { get; set; }

        public Guid FunctionId { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateGroupFunctionRequest(Guid groupId, Guid functionId, Guid? updateBy, DateTime? updateTime)
        {
            GroupId = groupId;
            FunctionId = functionId;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}