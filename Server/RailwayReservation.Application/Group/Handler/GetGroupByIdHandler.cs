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
    public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdQuery, GroupResponse>
    {
        private readonly IGroupRepository _repo;

        public GetGroupByIdHandler(IGroupRepository repo)
        {
            _repo = repo;
        }

        public async Task<GroupResponse> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetResponseById(request.Id);
        }
    }
}