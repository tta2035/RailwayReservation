using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Seat.DTO;
using RailwayReservation.Domain.Coach.ValueObjects;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class SeatRepository : GenericRepository<Domain.Seat.Seat, SeatResponse>, ISeatRepository
    {
        public SeatRepository(RailwayReservationDbContext context) : base(context)
        {
        }

        public override async Task<List<SeatResponse>> GetAll()
        {
            var result = await (from seat in table
                          join coach in _context.Coaches on seat.CoachId equals coach.Id
                          join train in _context.Trains on coach.TrainId equals train.Id
                          join st in _context.SeatTypes on seat.SeatTypeId equals st.Id
                          select new SeatResponse()
                          {
                              Id = seat.Id,
                              CoachId = coach.Id,
                              CoachNo = coach.CoachNo,
                              TrainName = train.TrainName,
                              SeatTypeId = st.Id,
                              SeatTypeName = st.SeatTypeName,
                              SeatNo = seat.SeatNo,
                              Description = seat.Description,
                              CreateBy = seat.CreateBy,
                              CreateTime = seat.CreateTime,
                              UpdateBy = seat.UpdateBy,
                              UpdateTime = seat.UpdateTime,
                          }).ToListAsync();
            return result;
        }

        public async Task<List<SeatResponse>> GetByCoach(Guid coachId)
        {
            var list = await GetAll();
            return list.Where(e => e.CoachId == coachId).ToList();
        }

        public async override Task<SeatResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id == id).Single();
        }
    }
}