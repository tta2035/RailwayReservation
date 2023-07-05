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
        private readonly IBookingStatusRepository _repo;

        public GetCoachListHandler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public Task<List<CoachResponse>> Handle(GetCoachListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}