using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Coach.Commands;
using RailwayReservation.Application.Coach.DTO;
using RailwayReservation.Application.Coach.Queries;
using RailwayReservation.Domain.Coach;

namespace RailwayReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoachController : ControllerBase
{
    private readonly IMediator mediator;

    public CoachController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<CoachResponse>> GetCoachList()
    {
        var query = new GetCoachListQuery();
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
    public async Task<CoachResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetCoachByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<Coach> Add(CreateCoachRequest obj)
    {
        var result = await mediator.Send(new CreateCoachCommand(
            obj.CoachNo,
            obj.TrainId,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateCoachRequest obj)
    {
        var result = await mediator.Send(new UpdateCoachCommand(
            obj.Id,
            obj.CoachNo,
            obj.TrainId,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteCoachCommand() { Id = id });
    }
}
