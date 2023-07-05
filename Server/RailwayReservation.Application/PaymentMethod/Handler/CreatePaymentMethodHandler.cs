using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.PaymentMethod.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Handler
{
    public class CreatePaymentMethodHandler : IRequestHandler<CreatePaymentMethodCommand, Domain.PaymentMethod.PaymentMethod>
    {
        private readonly IPaymentMethodRepository _repo;

        public CreatePaymentMethodHandler(IPaymentMethodRepository repo)
        {
            _repo = repo;
        }

        public Task<Domain.PaymentMethod.PaymentMethod> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}