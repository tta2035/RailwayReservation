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
    public class GetFunctionByIdHandler : IRequestHandler<GetFunctionByIdQuery, FunctionResponse>
    {
        private readonly IFunctionRepository _repo;

        public GetFunctionByIdHandler(IFunctionRepository repo)
        {
            _repo = repo;
        }

        public async Task<FunctionResponse> Handle(GetFunctionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetResponseById(request.Id);
        }
    }
}