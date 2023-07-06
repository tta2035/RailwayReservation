using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Train.Commands;
using RailwayReservation.Application.Train.DTO;
using RailwayReservation.Application.Train.Queries;
using RailwayReservation.Domain.Train;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TrainController : ControllerBase
{
    private readonly IMediator mediator;

    public TrainController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<TrainResponse>> GetTrainList()
    {
        var query = new GetTrainListQuery();
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
    public async Task<TrainResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetTrainByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<Train> Add(CreateTrainRequest obj)
    {
        var result = await mediator.Send(new CreateTrainCommand(
            obj.TrainName,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateTrainRequest obj)
    {
        var result = await mediator.Send(new UpdateTrainCommand(
            obj.Id,
            obj.TrainName,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteTrainCommand() { Id = id });
    }
}
