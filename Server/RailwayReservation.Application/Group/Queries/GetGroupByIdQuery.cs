using MediatR;
using RailwayReservation.Application.Group.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Group.Queries
{
    public class GetGroupByIdQuery : IRequest<GroupResponse>
    {
        public Guid Id { get; set; }
    }
}