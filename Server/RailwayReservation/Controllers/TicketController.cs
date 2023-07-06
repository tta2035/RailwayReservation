using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Ticket.Commands;
using RailwayReservation.Application.Ticket.DTO;
using RailwayReservation.Application.Ticket.Queries;
using RailwayReservation.Domain.Ticket;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly IMediator mediator;

    public TicketController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<TicketResponse>> GetTicketList()
    {
        var query = new GetTicketListQuery();
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
    public async Task<TicketResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetTicketByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<Ticket> Add(CreateTicketRequest obj)
    {
        var result = await mediator.Send(new CreateTicketCommand(
            obj.TripId,
            obj.SeatId,
            obj.Fare,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime,
            obj.Status
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateTicketRequest obj)
    {
        var result = await mediator.Send(new UpdateTicketCommand(
            obj.Id,
            obj.TripId,
            obj.SeatId,
            obj.Fare,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime,
            obj.Status
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteTicketCommand() { Id = id });
    }
}
