using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Route.Commands
{
    public class DeleteRouteCommand : IRequest<int>
    {
        public Guid id { get; set; }
    }
}