using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.GroupUser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.Handler
{
    public class UpdateGroupUserHandler : IRequestHandler<UpdateGroupUserCommand, int>
    {
        private readonly IGroupUserRepository _repo;

        public UpdateGroupUserHandler(IGroupUserRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateGroupUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}