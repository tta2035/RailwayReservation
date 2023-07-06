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

        public async Task<int> Handle(UpdateFunctionCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.getById(request.Id);
            item.FunctionName = request.FunctionName;
            item.UpdateBy = request.UpdateBy;
            item.UpdateTime = DateTime.UtcNow;

            return await _repo.Update(item);
        }
    }
}