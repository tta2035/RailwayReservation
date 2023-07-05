using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.GroupFunction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupFunction.Handler
{
    public class CreateGroupFunctionHandler : IRequestHandler<CreateGroupFunctionCommand, Domain.GroupFunction.GroupFunction>
    {
        private readonly IGroupFunctionRepository _repo;

        public CreateGroupFunctionHandler(IGroupFunctionRepository repo)
        {
            _repo = repo;
        }

        public Task<Domain.GroupFunction.GroupFunction> Handle(CreateGroupFunctionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}