using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.PaymentMethod.DTO;
using RailwayReservation.Application.PaymentMethod.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Handler
{
    public class GetPaymentMethodByIdHandler : IRequestHandler<GetPaymentMethodByIdQuery, PaymentMethodResponse>
    {
        private readonly IPaymentMethodRepository _repo;

        public GetPaymentMethodByIdHandler(IPaymentMethodRepository repo)
        {
            _repo = repo;
        }

        public Task<PaymentMethodResponse> Handle(GetPaymentMethodByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}