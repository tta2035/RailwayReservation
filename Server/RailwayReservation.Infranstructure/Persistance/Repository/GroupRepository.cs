using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Group.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class GroupRepository
        : GenericRepository<Domain.Group.Group, GroupResponse>,
            IGroupRepository
    {
        public GroupRepository(RailwayReservationDbContext context)
            : base(context) { }

        public override async Task<List<GroupResponse>> GetAll()
        {
            var result = await (from gr in table
                          select new GroupResponse()
                          {
                              Id = gr.Id,
                              GroupName = gr.GroupName,
                              CreateBy = gr.CreateBy,
                              CreateTime = gr.CreateTime,
                              UpdateBy = gr.UpdateBy,
                              UpdateTime = gr.UpdateTime,
                              Functions = (from GF in _context.GroupFunctions
                                           join F in _context.Functions on GF.FunctionId equals F.Id
                                           where GF.GroupId == gr.Id
                                           select F).ToList(),
                              Users = (from GU in _context.GroupUsers
                                       join user in _context.Users on GU.UserId equals user.Id
                                       where GU.GroupId == gr.Id
                                       select user).ToList(),
                          }).ToListAsync();
            return result;
        }

        public override async Task<GroupResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id  == id).Single();
        }
    }
}
