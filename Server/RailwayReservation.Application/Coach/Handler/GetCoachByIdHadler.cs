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
        private readonly IBookingStatusRepository _repo;

        public GetCoachByIdHadler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public Task<CoachResponse> Handle(GetCoachByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}