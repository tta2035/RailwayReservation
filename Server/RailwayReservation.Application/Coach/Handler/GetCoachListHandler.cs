using MediatR;
using RailwayReservation.Application.Coach.DTO;
using RailwayReservation.Application.Coach.Queries;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.Handler
{
    public class GetCoachListHandler : IRequestHandler<GetCoachListQuery, List<CoachResponse>>
    {
        private readonly ICoachRepository _repo;

        public GetCoachListHandler(ICoachRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CoachResponse>> Handle(GetCoachListQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}