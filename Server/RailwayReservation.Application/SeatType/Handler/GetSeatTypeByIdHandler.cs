using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.SeatType.DTO;
using RailwayReservation.Application.SeatType.Queries;
using RailwayReservation.Application.Station.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.SeatType.Handler
{
    public class GetSeatTypeByIdHandler : IRequestHandler<GetSeatTypeByIdQuery, SeatTypeResponse>
    {
        private ISeatTypeRepository _repo;

        public GetSeatTypeByIdHandler(ISeatTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<SeatTypeResponse> Handle(GetSeatTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetResponseById(request.Id);
            if (item is null) return default;
            return item;
        }
    }
}