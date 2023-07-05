using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.Commands
{
    public class CreateGroupCommand : IRequest<Domain.Group.Group>
    {
        public string GroupName { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateGroupCommand(string groupName, Guid? createBy, DateTime? createTime)
        {
            GroupName = groupName;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}