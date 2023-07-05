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
    public class GetPaymentMethodListHandler : IRequestHandler<GetPaymentMethodListQuery, List<PaymentMethodResponse>>
    {
        private readonly IPaymentMethodRepository _repo;

        public GetPaymentMethodListHandler(IPaymentMethodRepository repo)
        {
            _repo = repo;
        }

        public Task<List<PaymentMethodResponse>> Handle(GetPaymentMethodListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}