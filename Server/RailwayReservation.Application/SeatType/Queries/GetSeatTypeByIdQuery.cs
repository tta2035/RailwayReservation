using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.SeatType.DTO;

namespace RailwayReservation.Application.SeatType.Queries
{
    public class GetSeatTypeByIdQuery : IRequest<SeatTypeResponse>
    {
        public Guid Id  { get; set; }
    }
}