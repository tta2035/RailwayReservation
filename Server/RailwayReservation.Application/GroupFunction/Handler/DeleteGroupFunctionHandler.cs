using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.GroupFunction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.GroupFunction.Handler
{
    public class DeleteGroupFunctionHandler : IRequestHandler<DeleteGroupFunctionCommand, int>
    {
        private readonly IGroupFunctionRepository _repo;

        public DeleteGroupFunctionHandler(IGroupFunctionRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeleteGroupFunctionCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetBy2Id(request.GroupId, request.FunctionId);
            return await _repo.DeleteGroupFunction(request.GroupId, request.FunctionId);
        }
    }
}