using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Function.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Handler
{
    public class UpdateFunctionHandler : IRequestHandler<UpdateFunctionCommand, int>
    {
        private readonly IFunctionRepository _repo;

        public UpdateFunctionHandler(IFunctionRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateFunctionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}