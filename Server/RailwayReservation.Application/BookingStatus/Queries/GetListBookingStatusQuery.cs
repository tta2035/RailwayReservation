using MediatR;
using RailwayReservation.Application.BookingStatus.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.BookingStatus.Queries
{
    public class GetListBookingStatusQuery : IRequest<List<BookingStatusResponse>>
    {
        
    }
}