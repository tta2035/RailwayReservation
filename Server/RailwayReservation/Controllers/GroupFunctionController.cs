using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.GroupFunction.Commands;
using RailwayReservation.Application.GroupFunction.DTO;
using RailwayReservation.Domain.GroupFunction;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class GroupFunctionController : ControllerBase
{
    private readonly IMediator mediator;

    public GroupFunctionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("add")]
    public async Task<GroupFunction> Add(CreateGroupFunctionRequest obj)
    {
        var result = await mediator.Send(new CreateGroupFunctionCommand(
            obj.GroupId,
            obj.FunctionId,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateGroupFunctionRequest obj)
    {
        var result = await mediator.Send(new UpdateGroupFunctionCommand(
            obj.GroupId,
            obj.FunctionId,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid groupId, Guid functionId)
    {
        return await mediator.Send(new DeleteGroupFunctionCommand() { GroupId = groupId, FunctionId = functionId });
    }
}
