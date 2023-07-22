using MediatR;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Application.User.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.User.Handler;

public class AuthenticationHandler : IRequestHandler<AuthenticationQuery, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasing _passwordHasing;

    public AuthenticationHandler(IUserRepository userRepository,
        IPasswordHasing passwordHasing)
    {
        _userRepository = userRepository;
        _passwordHasing = passwordHasing;
    }

    public Task<UserDto> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
    {
        _userRepository.Authentication(request.Email, request.Password);
        throw new NotImplementedException();
    }
}
