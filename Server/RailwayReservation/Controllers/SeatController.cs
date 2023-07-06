using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Seat.Commands;
using RailwayReservation.Application.Seat.DTO;
using RailwayReservation.Application.Seat.Queries;
using RailwayReservation.Domain.Seat;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    private readonly IMediator mediator;

    public SeatController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<SeatResponse>> GetSeatList()
    {
        var query = new GetSeatListQuery();
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
    public async Task<SeatResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetSeatByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<Seat> Add(CreateSeatRequest obj)
    {
        var result = await mediator.Send(new CreateSeatCommand(
            obj.CoachId,
            obj.SeatTypeId,
            obj.SeatNo,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateSeatRequest obj)
    {
        var result = await mediator.Send(new UpdateSeatCommand(
            obj.Id,
            obj.CoachId,
            obj.SeatTypeId,
            obj.SeatNo,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteSeatCommand() { Id = id });
    }
}
