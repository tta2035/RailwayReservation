using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.BookingStatus.Commands
{
    public class DeleteBookingStatusCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}