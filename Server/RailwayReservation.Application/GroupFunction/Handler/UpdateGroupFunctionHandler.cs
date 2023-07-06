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

        public async Task<int> Handle(UpdateGroupFunctionCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetBy2Id(request.GroupId, request.FunctionId);
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;

            return await _repo.Update(item);
        }
    }
}