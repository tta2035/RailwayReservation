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
    public class GetCoachByIdHadler : IRequestHandler<GetCoachByIdQuery, CoachResponse>
    {
        private readonly ICoachRepository _repo;

        public GetCoachByIdHadler(ICoachRepository repo)
        {
            _repo = repo;
        }

        public Task<CoachResponse> Handle(GetCoachByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetResponseById(request.Id);
        }
    }
}