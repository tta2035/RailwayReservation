using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Train.Commands
{
    public class CreateTrainCommand : IRequest<Domain.Train.Train>
    {
        public string TrainName { get; set; }
        public string? Description { get; set; }
    }
}