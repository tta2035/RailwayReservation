using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.User.Commands;
using RailwayReservation.Application.User.DTOs;

namespace RailwayReservation.Application.User.Handler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jtw;

        public UpdateUserHandler(IUserRepository userRepository, IJwtTokenGenerator jtw)
        {
            _userRepository = userRepository;
            _jtw = jtw;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = _userRepository.getById(request.Id).Result;
            if(result is null) return default;

            result.UserName = request.UserName;
            result.Email = request.Email;
            result.Password = request.Password;
            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.Token = request.Token;
            result.UpdateBy = request.UpdateBy;
            result.UpdateTime = DateTime.UtcNow;

            return await _userRepository.Update(result);
        }
    }
}