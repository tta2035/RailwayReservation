using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Group.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.Handler
{
    public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, int>
    {
        private readonly IGroupRepository _repo;

        public UpdateGroupHandler(IGroupRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}