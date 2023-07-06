using MediatR;
using RailwayReservation.Application.BookingStatus.DTO;
using RailwayReservation.Application.BookingStatus.Queries;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingStatus.Handler
{
    public class GetBookingStatusByIdHandler : IRequestHandler<GetBookingStatusByIdQuery, BookingStatusResponse>
    {
        private readonly IBookingStatusRepository _repo;

        public GetBookingStatusByIdHandler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<BookingStatusResponse> Handle(GetBookingStatusByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetResponseById(request.Id);
        }
    }
}