using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Coach.DTO;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.Coach;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class CoachRepository : GenericRepository<Domain.Coach.Coach, CoachResponse>, ICoachRepository
    {
        private readonly ISeatRepository _seatRepository;
        public CoachRepository(RailwayReservationDbContext context, ISeatRepository seatRepository) : base(context)
        {
            _seatRepository = seatRepository;
        }

        public override async Task<List<CoachResponse>> GetAll()
        {
            var result = await (from coach in table 
                          join train in _context.Trains on coach.TrainId equals train.Id
                          select new CoachResponse()
                          {
                              Id = coach.Id,
                              CoachNo = coach.CoachNo,
                              TrainId = coach.TrainId,
                              TrainName = train.TrainName,
                              Description = coach.Description,
                              CreateBy = coach.CreateBy,
                              CreateTime = coach.CreateTime,
                              UpdateBy = coach.UpdateBy,
                              UpdateTime = coach.UpdateTime,
                              ListSeat = new() // _seatRepository.GetByCoach(coach.Id)
                          }).ToListAsync();
            foreach(var item in result)
            {
                item.ListSeat = await _seatRepository.GetByCoach(item.Id);
            }
            return result;
        }

        public async Task<List<CoachResponse>> GetByTrainId(Guid trainId)
        {
            var list = await GetAll();
            return list.Where(e => e.TrainId == trainId).ToList();
        }

        public async override Task<CoachResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id == id).Single();
        }
    }
}