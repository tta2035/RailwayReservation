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
    public class GetListBookingStatusHandler : IRequestHandler<GetListBookingStatusQuery, List<BookingStatusResponse>>
    {
        private readonly IBookingStatusRepository _repo;

        public GetListBookingStatusHandler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public Task<List<BookingStatusResponse>> Handle(GetListBookingStatusQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}