using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.DTO
{
    public class UpdateFunctionRequest
    {
        public Guid Id { get; set; }

        public string FunctionName { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateFunctionRequest(Guid id, string functionName, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            FunctionName = functionName;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}