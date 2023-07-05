using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Function.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Handler
{
    public class DeleteFunctionHandler : IRequestHandler<DeleteFunctionCommand, int>
    {
        private readonly IFunctionRepository _repo;

        public DeleteFunctionHandler(IFunctionRepository repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(DeleteFunctionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}