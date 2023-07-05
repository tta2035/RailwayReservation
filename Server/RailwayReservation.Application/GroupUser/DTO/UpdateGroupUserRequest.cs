using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.DTO
{
    public class UpdateGroupUserRequest
    {
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateGroupUserRequest(Guid groupId, Guid userId, Guid? updateBy, DateTime? updateTime)
        {
            GroupId = groupId;
            UserId = userId;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}