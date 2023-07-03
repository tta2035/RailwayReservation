using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Route.Commands;
using RailwayReservation.Application.Route.DTO;
using RailwayReservation.Application.Route.Queries;
using RailwayReservation.Application.Station.Commands;
using RailwayReservation.Application.Station.DTO;
using RailwayReservation.Application.Station.Queries;
using RailwayReservation.Domain.Station;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class StationController : ControllerBase
{
    private readonly IMediator mediator;

    public StationController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<StationResponse>> GetStationList()
    {
        var query = new GetStationListQuery();
        if (query is null)
        {
            throw new Exception("query is null");
        }
        var Stations = await mediator.Send(query);
        if (Stations is null)
        {
            throw new Exception("không có giá trị trả về");
        }
        return Stations;
    }

    [HttpGet("id")]
    public async Task<StationResponse> GetStationId(Guid id)
    {
        var Station = await mediator.Send(new GetStationByIdQuery() { Id = id });
        return Station;
    }

    [HttpPost]
    public async Task<Domain.Station.Station> AddStation(StationCreateRequest obj)
    {
        var StationSend = await mediator.Send(new CreateStationCommand(
            obj.StationName,
            obj.Description
            ));
        return StationSend;
    }

    [HttpPut]
    public async Task<int> UpdateStation(StationUpdateRequest obj)
    {
        var result = await mediator.Send(new UpdateStationCommand(
            obj.Id,
            obj.StationName,
            obj.Description,
            obj.UpdateBy,
            DateTime.UtcNow
            ));
        return result;
    }

    [HttpDelete]
    public async Task<int> DeleteStation(Guid id)
    {
        return await mediator.Send(new DeleteStationCommand() { Id = id });
    }
}
