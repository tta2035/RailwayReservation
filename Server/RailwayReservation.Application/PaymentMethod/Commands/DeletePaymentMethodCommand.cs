using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Commands
{
    public class DeletePaymentMethodCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}