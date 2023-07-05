using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.DTO
{
    public class GroupResponse
    {
        public Guid Id { get; set; }

        public string GroupName { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }
        public List<Domain.Function.Function> Functions { get; set; } = new();
        public List<Domain.User.User> Users { get; set; } = new();
    }
}