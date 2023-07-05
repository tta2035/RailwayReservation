using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.GroupUser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupUser.Handler
{
    public class DeleteGroupUserHandler : IRequestHandler<DeleteGroupUserCommand, int>
    {
        private readonly IGroupUserRepository _repo;

        public DeleteGroupUserHandler(IGroupUserRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(DeleteGroupUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}