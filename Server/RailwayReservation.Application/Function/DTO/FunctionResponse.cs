using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.DTO
{
    public class FunctionResponse
    {
        public Guid Id { get; set; }

        public string FunctionName { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public List<Domain.Group.Group> Groups { get; set; } = new();
        public List<Domain.User.User> Users { get; set; } = new();

        public FunctionResponse(Guid id, string functionName, Guid? createBy, DateTime? createTime, Guid? updateBy, DateTime? updateTime, List<Domain.Group.Group> groups, List<Domain.User.User> users)
        {
            Id = id;
            FunctionName = functionName;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
            Groups = groups;
            Users = users;
        }

        public FunctionResponse()
        {
        }
    }
}