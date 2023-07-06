using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.GroupUser.Commands;
using RailwayReservation.Application.GroupUser.DTO;
using RailwayReservation.Domain.GroupUser;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class GroupUserController : ControllerBase
{
    private readonly IMediator mediator;

    public GroupUserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("add")]
    public async Task<GroupUser> Add(CreateGroupUserRequest obj)
    {
        var result = await mediator.Send(new CreateGroupUserCommand(
            obj.GroupId,
            obj.UserId,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateGroupUserRequest obj)
    {
        var result = await mediator.Send(new UpdateGroupUserCommand(
            obj.GroupId,
            obj.UserId,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid groupId, Guid userId)
    {
        return await mediator.Send(new DeleteGroupUserCommand() { GroupId = groupId, UserId = userId });
    }
}
