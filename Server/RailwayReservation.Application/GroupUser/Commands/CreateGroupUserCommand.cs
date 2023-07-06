using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.Commands
{
    public class CreateGroupUserCommand : IRequest<Domain.GroupUser.GroupUser>
    {

        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateGroupUserCommand(Guid groupId, Guid userId, Guid? createBy, DateTime? createTime)
        {
            GroupId = groupId;
            UserId = userId;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}