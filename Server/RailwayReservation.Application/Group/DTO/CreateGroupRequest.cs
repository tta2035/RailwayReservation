using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.DTO
{
    public class CreateGroupRequest
    {

        public string GroupName { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateGroupRequest(string groupName, Guid? createBy, DateTime? createTime)
        {
            GroupName = groupName;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}