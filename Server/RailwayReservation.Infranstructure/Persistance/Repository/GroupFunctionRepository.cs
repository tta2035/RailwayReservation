using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class GroupFunctionRepository
        : GenericRepository<Domain.GroupFunction.GroupFunction, Domain.GroupFunction.GroupFunction>,
            IGroupFunctionRepository
    {
        public GroupFunctionRepository(RailwayReservationDbContext context)
            : base(context) { }
    }
}
