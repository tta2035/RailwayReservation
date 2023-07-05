using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Seat.Commands
{
    public class DeleteSeatCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}