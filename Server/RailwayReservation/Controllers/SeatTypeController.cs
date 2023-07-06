using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.SeatType.Commands;
using RailwayReservation.Application.SeatType.DTO;
using RailwayReservation.Application.SeatType.Queries;
using RailwayReservation.Domain.SeatType;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SeatTypeController : ControllerBase
{
    private readonly IMediator mediator;

    public SeatTypeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<SeatTypeResponse>> GetSeatTypeList()
    {
        var query = new GetSeatTypeByListQuery();
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
    public async Task<SeatTypeResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetSeatTypeByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<SeatType> Add(SeatTypeCreateRequest obj)
    {
        var result = await mediator.Send(new CreateSeatTypeCommand(
            obj.SeatTypeName,
            obj.RaitoFare,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(SeatTypeUpdateRequest obj)
    {
        var result = await mediator.Send(new UpdateSeatTypeCommand(
            obj.Id,
            obj.SeatTypeName,
            obj.RaitoFare,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteSeatTypeCommand() { Id = id });
    }
}
