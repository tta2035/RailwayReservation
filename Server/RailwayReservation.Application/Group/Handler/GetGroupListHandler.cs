using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Group.DTO;
using RailwayReservation.Application.Group.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.Handler
{
    public class GetGroupListHandler : IRequestHandler<GetGroupListQuery, List<GroupResponse>>
    {
        private readonly IGroupRepository _repo;

        public GetGroupListHandler(IGroupRepository repo)
        {
            _repo = repo;
        }

        public Task<List<GroupResponse>> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}