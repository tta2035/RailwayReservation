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
    public class GetCoachByTrainIdHandler : IRequestHandler<GetCoachByTrainIdQuery, List<CoachResponse>>
    {
        private readonly ICoachRepository _repo;

        public GetCoachByTrainIdHandler(ICoachRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CoachResponse>> Handle(GetCoachByTrainIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByTrainId(request.TrainId);
        }
    }
}