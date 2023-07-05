using MediatR;
using RailwayReservation.Application.PaymentMethod.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Queries
{
    public class GetPaymentMethodListQuery : IRequest<List<PaymentMethodResponse>>
    {
        
    }
}