using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.DTO
{
    public class UpdateGroupRequest
    {
        public Guid Id { get; set; }

        public string GroupName { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateGroupRequest(Guid id, string groupName, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            GroupName = groupName;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}