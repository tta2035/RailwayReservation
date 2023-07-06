using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Trip.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Trip.Handler
{
    public class UpdateTripHandler : IRequestHandler<UpdateTripCommand, int>
    {
        private readonly ITripRepository _repo;

        public UpdateTripHandler(ITripRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);

            item.Id = request.Id;
            item.TrainId = request.TrainId;
            item.RouteId = request.RouteId;
            item.DepartureTime = request.DepartureTime;
            item.ArriveTime = request.ArriveTime;
            item.Description = request.Description;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;
            return await _repo.Update(item);

        }
    }
}