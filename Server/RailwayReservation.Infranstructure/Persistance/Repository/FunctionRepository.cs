using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Function.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class FunctionRepository : GenericRepository<Domain.Function.Function, FunctionResponse>, IFunctionRepository
    {
        public FunctionRepository(RailwayReservationDbContext context) : base(context)
        {
        }

        public override async Task<List<FunctionResponse>> GetAll()
        {
            var result = await (from function in table
                          select new FunctionResponse()
                          {
                              Id = function.Id,
                              FunctionName = function.FunctionName,
                              CreateBy = function.CreateBy,
                              CreateTime = function.CreateTime,
                              UpdateBy = function.UpdateBy,
                              UpdateTime = function.UpdateTime,
                              Groups = (from GF in _context.GroupFunctions
                                        join GR in _context.Groups on GF.GroupId equals GR.Id
                                        where(GF.FunctionId ==  function.Id)
                                        select GR).ToList(),
                              Users = (from GF in _context.GroupFunctions
                                       join GU in _context.GroupUsers on GF.GroupId equals GU.GroupId
                                       join user in _context.Users on GU.UserId equals user.Id
                                       select user
                                       ).ToList()
                          }).ToListAsync();
            return result;
        }

        public override async Task<FunctionResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id == id).Single();
        }
    }
}