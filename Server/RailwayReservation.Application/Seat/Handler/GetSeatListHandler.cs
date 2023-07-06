using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Seat.DTO;
using RailwayReservation.Application.Seat.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Seat.Handler
{
    public class GetSeatListHandler : IRequestHandler<GetSeatListQuery, List<SeatResponse>>
    {
        private readonly ISeatRepository _repo;

        public GetSeatListHandler(ISeatRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SeatResponse>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}