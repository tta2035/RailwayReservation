using MediatR;
using RailwayReservation.Application.PaymentMethod.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Queries
{
    public class GetPaymentMethodByIdQuery : IRequest<PaymentMethodResponse>
    {
        public Guid Id { get; set; }
    }
}