using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Train.Commands
{
    public class DeleteTrainCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}