using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.PaymentMethod.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class PaymentMethodRepository
        : GenericRepository<Domain.PaymentMethod.PaymentMethod, PaymentMethodResponse>,
            IPaymentMethodRepository
    {
        public PaymentMethodRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}
