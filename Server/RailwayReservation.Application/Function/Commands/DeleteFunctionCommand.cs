using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Commands
{
    public class DeleteFunctionCommand : IRequest<int>
    {
        public int Id { get; set; }
        
    }
}