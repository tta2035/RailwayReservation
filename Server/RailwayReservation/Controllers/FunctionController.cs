using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Function.Commands;
using RailwayReservation.Application.Function.DTO;
using RailwayReservation.Application.Function.Queries;
using RailwayReservation.Domain.Function;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class FunctionController : ControllerBase
{
    private readonly IMediator mediator;

    public FunctionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<FunctionResponse>> GetFunctionList()
    {
        var query = new GetFunctionListQuery();
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
    public async Task<FunctionResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetFunctionByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<Function> Add(CreateFunctionRequest obj)
    {
        var result = await mediator.Send(new CreateFunctionCommand(
            obj.FunctionName,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateFunctionRequest obj)
    {
        var result = await mediator.Send(new UpdateFunctionCommand(
            obj.Id,
            obj.FunctionName,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteFunctionCommand() { Id = id });
    }
}
