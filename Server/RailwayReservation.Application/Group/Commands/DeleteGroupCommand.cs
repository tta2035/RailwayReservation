using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.Commands
{
    public class DeleteGroupCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}