using MediatR;
using RailwayReservation.Application.Function.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Function.Queries
{
    public class GetFunctionListQuery : IRequest<List<FunctionResponse>>
    {
        
    }
}