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
    public class GetSeatByIdHandler : IRequestHandler<GetSeatByIdQuery, SeatResponse>
    {
        private readonly ISeatRepository _repo;

        public GetSeatByIdHandler(ISeatRepository repo)
        {
            _repo = repo;
        }

        public async Task<SeatResponse> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetResponseById(request.Id);
        }
    }
}