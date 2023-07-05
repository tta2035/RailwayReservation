using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.DTO
{
    public class CreateFunctionRequest
    {

        public string FunctionName { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateFunctionRequest(string functionName, Guid? createBy, DateTime? createTime)
        {
            FunctionName = functionName;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}