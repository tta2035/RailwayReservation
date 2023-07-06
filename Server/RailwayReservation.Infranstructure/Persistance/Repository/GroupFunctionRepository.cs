using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.GroupFunction;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class GroupFunctionRepository
        : GenericRepository<Domain.GroupFunction.GroupFunction, Domain.GroupFunction.GroupFunction>,
            IGroupFunctionRepository
    {
        public GroupFunctionRepository(RailwayReservationDbContext context)
            : base(context) { }

        public async Task<int> DeleteGroupFunction(Guid GroupId, Guid FunctionId)
        {
            var item = await GetBy2Id(GroupId, FunctionId);
            table.Remove(item);
            return _context.SaveChanges();
        }

        public override Task<List<GroupFunction>> GetAll()
        {
            
            return base.GetAll();
        }

        public async Task<GroupFunction> GetBy2Id(Guid GroupId, Guid FunctionId)
        {
            var item = table.Where(e => e.GroupId == GroupId && e.FunctionId == FunctionId).Single();
            return item;
        }
    }
}
