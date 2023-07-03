using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.User.Commands;
using RailwayReservation.Application.User.DTOs;

namespace RailwayReservation.Application.User.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Domain.User.User>
    {
        private readonly IUserRepository _userPepository;

        public CreateUserHandler(IUserRepository userPepository)
        {
            _userPepository = userPepository;
        }

        public async Task<Domain.User.User> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = Domain.User.User.Create(
                request.UserName,
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName,
                request.Token
            );
            return await _userPepository.Insert(user);
        }
    }
}
