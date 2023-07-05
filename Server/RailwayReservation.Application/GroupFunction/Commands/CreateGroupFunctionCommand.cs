using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupFunction.Commands
{
    public class CreateGroupFunctionCommand : IRequest<Domain.GroupFunction.GroupFunction>
    {
        public Guid GroupId { get; set; }

        public Guid FunctionId { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateGroupFunctionCommand(Guid groupId, Guid functionId, Guid? createBy, DateTime? createTime)
        {
            GroupId = groupId;
            FunctionId = functionId;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}