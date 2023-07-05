using MediatR;
using RailwayReservation.Application.Coach.Commands;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Coach.Handler;

public class CreateCoachHandler : IRequestHandler<CreateCoachCommand, Domain.Coach.Coach>
{
    private readonly ICoachRepository _repo;

    public CreateCoachHandler(ICoachRepository repo)
    {
        _repo = repo;
    }

    public Task<Domain.Coach.Coach> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}