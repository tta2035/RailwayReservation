using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Group.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.Handler
{
    public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, Domain.Group.Group>
    {
        private readonly IGroupRepository _repo;

        public CreateGroupHandler(IGroupRepository repo)
        {
            _repo = repo;
        }

        public async Task<Domain.Group.Group> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var item = Domain.Group.Group.Create(
                request.GroupName,
                request.CreateBy
            );
            return await _repo.Insert(item);
        }
    }
}