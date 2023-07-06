using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Train.DTO;
using RailwayReservation.Domain.Train;

namespace RailwayReservation.Infranstructure.Persistance.Repository;

public class TrainRepository
    : GenericRepository<Domain.Train.Train, TrainResponse>,
        ITrainRepository
{
    private readonly ICoachRepository _coachRepository;
    public TrainRepository(RailwayReservationDbContext context,
        ICoachRepository coachRepository)
        : base(context) { 
        _coachRepository = coachRepository;
    }

    public override async Task<List<TrainResponse>> GetAll()
    {
        var result = await (from train in table
                            select new TrainResponse()
                            {
                                Id = train.Id,
                                TrainName = train.TrainName,
                                Description = train.Description,
                                CreateBy = train.CreateBy,
                                CreateTime = train.CreateTime,
                                UpdateBy = train.UpdateBy,
                                UpdateTime = train.UpdateTime,
                                CoachQuantity = _context.Coaches.Count(e => e.TrainId == train.Id),
                                Coaches = new()
                            }).ToListAsync();
        foreach(var item in result)
        {
            item.Coaches = await _coachRepository.GetByTrainId(item.Id);
        }
        return result;
    }

    public async Task<TrainResponse> GetTrainResponseById(Guid Id)
    {
        var list = await GetAll();
        return list.Where(e => e.Id == Id).Single();
    }
}
