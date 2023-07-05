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
        private readonly IBookingStatusRepository _repo;

        public GetCoachByTrainIdHandler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public Task<List<CoachResponse>> Handle(GetCoachByTrainIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}