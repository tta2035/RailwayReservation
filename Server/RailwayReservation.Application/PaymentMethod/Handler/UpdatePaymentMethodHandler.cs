using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.PaymentMethod.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Handler
{
    public class UpdatePaymentMethodHandler : IRequestHandler<UpdatePaymentMethodCommand, int>
    {
        private readonly IPaymentMethodRepository _repo;

        public UpdatePaymentMethodHandler(IPaymentMethodRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}