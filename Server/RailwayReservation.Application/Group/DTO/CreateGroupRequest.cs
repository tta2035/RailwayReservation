using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.DTO
{
    public class CreateGroupRequest
    {

        public string GroupName { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public CreateGroupRequest(string groupName, Guid? updateBy, DateTime? updateTime)
        {
            GroupName = groupName;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}