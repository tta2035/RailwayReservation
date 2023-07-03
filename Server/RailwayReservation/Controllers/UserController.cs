using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.User.Commands;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Application.User.Queries;
using RailwayReservation.Domain.User;

namespace RailwayReservation.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetUserList()
        {
            var query = new GetUserListQuery();
            if(query is null)
            {
                throw new Exception("query is null");
            }
            var Users = await mediator.Send(query);
            if(Users is null)
            {
                throw new Exception("lỗi khi dùng mediator.Send");
            }
            return Users;
        }

        [HttpGet("id")]
        public async Task<UserDto> GetUserId(Guid id) {
            var user = await mediator.Send(new GetUserByIdQuery() { Id = id });
            return user;
        }

        [HttpPost]
        public async Task<User> AddUser(UserRequest obj) {
            var userSend = await mediator.Send(new CreateUserCommand(
                obj.UserName,
                obj.Email,
                obj.Password,
                obj.FirstName,
                obj.LastName,
                obj.Token
            ));
            return userSend;
        }

        [HttpPut]
        public async Task<int> UpdateUser(UserDto obj) {
            var result = await mediator.Send(new UpdateUserCommand(
                obj.Id,
                obj.UserName,
                obj.Email,
                obj.Password,
                obj.FirstName,
                obj.LastName,
                obj.Token,
                obj.UpdateBy,
                obj.UpdateTime
            ));
            return result;
        }

        [HttpDelete]
        public async Task<int> DeleteUser(Guid id) {
            return await mediator.Send(new DeleteUserCommand() { Id = id });
        }

    }
}
