using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.User.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}