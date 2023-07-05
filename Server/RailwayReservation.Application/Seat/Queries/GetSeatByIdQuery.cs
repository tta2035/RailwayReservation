using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Seat.DTO;

namespace RailwayReservation.Application.Seat.Queries
{
    public class GetSeatByIdQuery : IRequest<SeatResponse>
    {
        public Guid Id { get; set; }
    }
}