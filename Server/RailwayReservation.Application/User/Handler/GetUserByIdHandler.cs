using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Application.User.Queries;

namespace RailwayReservation.Application.User.Handler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _userRepository.getById(request.Id);
            // throw new Exception(result.Id.Value.ToString());
            if (result is null)
            {
                throw new ArgumentException("Không tìm thấy user hợp lệ");
            }
            try
            {
                var respone = new UserDto(result);
                return respone;
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể chuyển user sang user dto được");
            }
        }
    }
}
