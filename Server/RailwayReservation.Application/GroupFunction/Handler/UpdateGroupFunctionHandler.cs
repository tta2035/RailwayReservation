using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.GroupFunction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupFunction.Handler
{
    public class UpdateGroupFunctionHandler : IRequestHandler<UpdateGroupFunctionCommand, int>
    {
        private readonly IGroupFunctionRepository _repo;

        public UpdateGroupFunctionHandler(IGroupFunctionRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(UpdateGroupFunctionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}