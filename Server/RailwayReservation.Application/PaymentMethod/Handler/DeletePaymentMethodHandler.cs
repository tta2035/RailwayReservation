using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.PaymentMethod.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Handler
{
    public class DeletePaymentMethodHandler : IRequestHandler<DeletePaymentMethodCommand, int>
    {
        private readonly IPaymentMethodRepository _repo;

        public DeletePaymentMethodHandler(IPaymentMethodRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(request.Id);
        }
    }
}