using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.Commands
{
    public class DeleteGroupUserCommand : IRequest<int>
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}