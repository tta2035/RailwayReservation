using MediatR;
using RailwayReservation.Application.Coach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.Queries
{
    public class GetCoachByIdQuery : IRequest<CoachResponse>
    {
        public Guid Id { get; set; }
    }
}