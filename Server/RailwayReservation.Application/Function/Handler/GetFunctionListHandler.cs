using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Function.DTO;
using RailwayReservation.Application.Function.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Handler
{
    public class GetFunctionListHandler : IRequestHandler<GetFunctionListQuery, List<FunctionResponse>>
    {
        private readonly IFunctionRepository _repo;

        public GetFunctionListHandler(IFunctionRepository repo)
        {
            _repo = repo;
        }

        public Task<List<FunctionResponse>> Handle(GetFunctionListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}