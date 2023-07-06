using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.SeatType.DTO;
using RailwayReservation.Application.SeatType.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.SeatType.Handler
{
    public class GetSeatTypeByListHandler : IRequestHandler<GetSeatTypeByListQuery, List<SeatTypeResponse>>
    {
        private ISeatTypeRepository _repo;

        public GetSeatTypeByListHandler(ISeatTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SeatTypeResponse>> Handle(GetSeatTypeByListQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}