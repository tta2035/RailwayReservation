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

        public async Task<Domain.PaymentMethod.PaymentMethod> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var item = Domain.PaymentMethod.PaymentMethod.Create(
                request.PaymentMethodName,
                request.Description,
                request.CreateBy
                );
            return await _repo.Insert(item);
        }
    }
}