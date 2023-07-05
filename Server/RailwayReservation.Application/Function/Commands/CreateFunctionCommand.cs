using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Commands
{
    public class CreateFunctionCommand : IRequest<Domain.Function.Function>
    {

        public string FunctionName { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public CreateFunctionCommand(string functionName, Guid? createBy, DateTime? createTime)
        {
            FunctionName = functionName;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}