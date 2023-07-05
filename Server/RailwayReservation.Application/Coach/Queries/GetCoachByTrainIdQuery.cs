using MediatR;
using RailwayReservation.Application.Coach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.Queries
{
    public class GetCoachByTrainIdQuery : IRequest<List<CoachResponse>>
    {
        public Guid TrainId { get; set; }
    }
}