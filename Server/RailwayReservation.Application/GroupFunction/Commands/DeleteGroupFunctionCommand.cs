using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupFunction.Commands
{
    public class DeleteGroupFunctionCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}