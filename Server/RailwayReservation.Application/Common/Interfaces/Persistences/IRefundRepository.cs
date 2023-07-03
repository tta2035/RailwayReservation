using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IRefundRepository : IGenericRepository<Domain.Refund.Refund, Domain.Refund.Refund>
    {
        
    }
}