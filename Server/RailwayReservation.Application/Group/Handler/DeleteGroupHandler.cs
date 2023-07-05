using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Group.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.Handler
{
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, int>
    {
        private readonly IGroupRepository _repo;

        public DeleteGroupHandler(IGroupRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}