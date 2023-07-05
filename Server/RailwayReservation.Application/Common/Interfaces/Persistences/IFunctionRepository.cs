using RailwayReservation.Application.Function.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IFunctionRepository : IGenericRepository<Domain.Function.Function, FunctionResponse>
    {
        
    }
}