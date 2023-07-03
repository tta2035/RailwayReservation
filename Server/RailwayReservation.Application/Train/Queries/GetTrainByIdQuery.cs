using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Train.DTO;

namespace RailwayReservation.Application.Train.Queries
{
    public class GetTrainByIdQuery : IRequest<TrainResponse>
    {
        public Guid Id { get; set; }
    }
}