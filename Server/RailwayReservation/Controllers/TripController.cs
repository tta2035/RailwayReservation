using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Trip.Commands;
using RailwayReservation.Application.Trip.DTO;
using RailwayReservation.Application.Trip.Queries;
using RailwayReservation.Domain.Trip;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TripController : ControllerBase
{
    private readonly IMediator mediator;

    public TripController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<TripResponse>> GetTripList()
    {
        var query = new GetTripListQuery();
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
    public async Task<TripResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetTripByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<Trip> Add(CreateTripRequest obj)
    {
        var result = await mediator.Send(new CreateTripCommand(
            obj.TrainId,
            obj.RouteId,
            obj.DepartureTime,
            obj.ArriveTime,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateTripRequest obj)
    {
        var result = await mediator.Send(new UpdateTripCommand(
            obj.Id,
            obj.TrainId,
            obj.RouteId,
            obj.DepartureTime,
            obj.ArriveTime,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeleteTripCommand() { Id = id });
    }
}
