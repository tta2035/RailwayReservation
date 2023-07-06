using MediatR;
using RailwayReservation.Application.Coach.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.Handler
{
    public class UpdateCoachHadler : IRequestHandler<UpdateCoachCommand, int>
    {
        private readonly ICoachRepository _repo;

        public UpdateCoachHadler(ICoachRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);

            item.CoachNo = request.CoachNo;
            item.TrainId = request.TrainId;
            item.Description = request.Description;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;
            return await _repo.Update(item);
        }
    }
}