using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.DTO
{
    public class CreateGroupUserRequest
    {
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateGroupUserRequest(Guid groupId, Guid userId, Guid? createBy, DateTime? createTime)
        {
            GroupId = groupId;
            UserId = userId;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}