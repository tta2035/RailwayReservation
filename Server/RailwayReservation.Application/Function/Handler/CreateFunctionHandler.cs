using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Function.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Handler
{
    public class CreateFunctionHandler : IRequestHandler<CreateFunctionCommand, Domain.Function.Function>
    {
        private readonly IFunctionRepository _repo;

        public CreateFunctionHandler(IFunctionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Domain.Function.Function> Handle(CreateFunctionCommand request, CancellationToken cancellationToken)
        {
            var item = Domain.Function.Function.Create(
                request.FunctionName,
                request.CreateBy
            );
            return await _repo.Insert(item);
        }
    }
}