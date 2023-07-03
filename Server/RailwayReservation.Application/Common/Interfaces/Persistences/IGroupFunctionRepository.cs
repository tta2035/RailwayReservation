using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IGroupFunctionRepository : IGenericRepository<Domain.GroupFunction.GroupFunction, Domain.GroupFunction.GroupFunction>
    {
        
    }
}