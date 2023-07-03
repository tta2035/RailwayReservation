using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class RefundRepository
        : GenericRepository<Domain.Refund.Refund, Domain.Refund.Refund>,
            IRefundRepository
    {
        public RefundRepository(RailwayReservationDbContext context)
            : base(context) { }
    }
}
