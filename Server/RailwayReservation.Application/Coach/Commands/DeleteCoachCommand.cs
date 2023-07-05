using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.Commands
{
    public class DeleteCoachCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}