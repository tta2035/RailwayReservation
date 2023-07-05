using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Commands
{
    public class UpdateFunctionCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public string FunctionName { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateFunctionCommand(Guid id, string functionName, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            FunctionName = functionName;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}