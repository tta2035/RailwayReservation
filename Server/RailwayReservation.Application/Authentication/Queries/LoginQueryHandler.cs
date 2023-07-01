using ErrorOr;
using MediatR;
using RailwayReservation.Application.Authentication.Common;
using RailwayReservation.Application.Common;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Domain.Common.Errors;
using RailwayReservation.Domain.Passenger;
using RailwayReservation.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Authentication.Queries;

public class LoginQueryHandler
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator; 
    private readonly IPassengerRepository _passengerRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IPassengerRepository passengerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passengerRepository = passengerRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_passengerRepository.GetUserByEmail(request.Email) is not Passenger passenger)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        if(passenger.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jwtTokenGenerator.GenerateToken(passenger);
        return new AuthenticationResult(passenger, token);
    }
}
