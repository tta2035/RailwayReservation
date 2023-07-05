using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Function.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class FunctionRepository : GenericRepository<Domain.Function.Function, FunctionResponse>, IFunctionRepository
    {
        public FunctionRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}