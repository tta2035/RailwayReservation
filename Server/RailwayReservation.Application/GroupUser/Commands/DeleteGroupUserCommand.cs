using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.Commands
{
    public class DeleteGroupUserCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}