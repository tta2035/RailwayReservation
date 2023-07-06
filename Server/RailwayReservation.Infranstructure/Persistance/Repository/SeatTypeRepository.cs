using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.SeatType.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class SeatTypeRepository
        : GenericRepository<Domain.SeatType.SeatType, SeatTypeResponse>,
            ISeatTypeRepository
    {
        public SeatTypeRepository(RailwayReservationDbContext context)
            : base(context) { }

        public override async Task<List<SeatTypeResponse>> GetAll()
        {
            var result = await (from seat in table
                          select new SeatTypeResponse()
                          {
                              Id = seat.Id,
                              SeatTypeName = seat.SeatTypeName,
                              RaitoFare = seat.RaitoFare,
                              Description = seat.Description,
                              CreateBy = seat.CreateBy,
                              CreateTime = seat.CreateTime,
                              UpdateBy = seat.UpdateBy,
                              UpdateTime = seat.UpdateTime,
                          }).ToListAsync();
            return result;
        }

        public override async Task<SeatTypeResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id == id).Single();
        }
    }
}
