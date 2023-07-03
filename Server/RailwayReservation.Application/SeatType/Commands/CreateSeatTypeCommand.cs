using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.SeatType.Commands
{
    public class CreateSeatTypeCommand : IRequest<Domain.SeatType.SeatType>
    {
        
    }
}