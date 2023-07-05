using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.Commands
{
    public class CreateGroupUserCommand : IRequest<Domain.GroupUser.GroupUser>
    {

        public Guid UserId { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateGroupUserCommand(Guid userId, Guid? createBy, DateTime? createTime)
        {
            UserId = userId;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}