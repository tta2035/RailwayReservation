using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Commands
{
    public class DeleteTripCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}