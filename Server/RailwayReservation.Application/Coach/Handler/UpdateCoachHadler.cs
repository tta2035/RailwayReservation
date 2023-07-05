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
        private readonly IBookingStatusRepository _repo;

        public UpdateCoachHadler(IBookingStatusRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}