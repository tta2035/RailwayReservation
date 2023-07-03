using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Application.User.Queries;
using AutoMapper.Internal.Mappers;
using Mapster;

namespace RailwayReservation.Application.User.Handler
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll().Result;
            if(users is null)
            {
                throw new Exception("GetAll user in GetUserListHandler error.");
            }
            //List<UserDto> userDtos = new List<UserDto>();
            //foreach (var user in users)
            //{
            //    userDtos.Add(new UserDto(user));
            //}
            return users;
        }
    }
}