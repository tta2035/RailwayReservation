using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Group.Commands;
using RailwayReservation.Application.Group.DTO;
using RailwayReservation.Application.Group.Queries;
using RailwayReservation.Domain.Group;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IMediator mediator;

    public GroupController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<GroupResponse>> GetGroupList()
    {
        var query = new GetGroupListQuery();
        if (query is null)
        {
            throw new Exception("query is null");
        }
        var result = await mediator.Send(query);
        if (result is null)
        {
            throw new Exception("lỗi khi dùng mediator.Send");
        }
        return result;
    }

    [HttpGet("get-by-id/id")]
    public async Task<GroupResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetGroupByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<Group> Add(CreateGroupRequest obj)
    {
        var result = await mediator.Send(new CreateGroupCommand(
            obj.GroupName,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateGroupRequest obj)
    {
        var result = await mediator.Send(new UpdateGroupCommand(
            obj.Id,
            obj.GroupName,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteGroupCommand() { Id = id });
    }
}
