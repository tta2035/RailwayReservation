using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Route.Commands;
using RailwayReservation.Application.Route.DTO;
using RailwayReservation.Application.Route.Queries;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class RouteController : ControllerBase
{
    private readonly IMediator mediator;

    public RouteController(IMediator mediator) {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<RouteResponse>> GetRouteList()
    {
        var query = new GetRouteListQuery();
        if(query is null)
        {
            throw new Exception("query is null");
        }
        var Routes = await mediator.Send(query);
        if(Routes is null)
        {
            throw new Exception("không có giá trị trả về");
        }
        return Routes;
    }

    [HttpGet("id")]
    public async Task<RouteResponse> GetRouteId(Guid id) {
        var Route = await mediator.Send(new GetRouteByIdQuery() { Id = id });
        return Route;
    }

    [HttpPost]
    public async Task<Domain.Route.Route> AddRoute(RouteRequest obj) {
        var RouteSend = await mediator.Send(new CreateRouteCommand(
            obj.RouteName,
            obj.DepartureStation,
            obj.DestinationStation,
            obj.RouteFare,
            obj.Description,
            obj.CreateBy,
            DateTime.UtcNow
        ));
        return RouteSend;
    }

    [HttpPut]
    public async Task<int> UpdateRoute(RouteRequest obj) {
        var result = await mediator.Send(new UpdateRouteCommand(
            obj.Id,
            obj.RouteName,
            obj.DepartureStation,
            obj.DestinationStation,
            obj.RouteFare,
            obj.Description,
            obj.CreateBy,
            DateTime.UtcNow
        ));
        return result;
    }

    [HttpDelete]
    public async Task<int> DeleteRoute(Guid id) {
        return await mediator.Send(new DeleteRouteCommand() { id = id });
    }
}
