using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.GroupUser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.Handler
{
    public class CreateGroupUserHandler : IRequestHandler<CreateGroupUserCommand, Domain.GroupUser.GroupUser>
    {
        private readonly IGroupUserRepository _repo;

        public CreateGroupUserHandler(IGroupUserRepository repo)
        {
            _repo = repo;
        }

        public Task<Domain.GroupUser.GroupUser> Handle(CreateGroupUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}