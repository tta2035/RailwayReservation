using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.BookingStatus.Commands;
using RailwayReservation.Application.BookingStatus.DTO;
using RailwayReservation.Application.BookingStatus.Queries;
using RailwayReservation.Domain.BookingStatus;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class BookingStatusController : ControllerBase
{
    private readonly IMediator mediator;

    public BookingStatusController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<BookingStatusResponse>> GetBookingStatusList()
    {
        var query = new GetListBookingStatusQuery();
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

    [HttpGet("id")]
    public async Task<BookingStatusResponse> GetById(Guid id)
    {
        var result = await mediator.Send(new GetBookingStatusByIdQuery() { Id = id });
        return result;
    }

    [HttpPost]
    public async Task<BookingStatus> Add(CreateBookingStatusRequest obj)
    {
        var result = await mediator.Send(new CreateBookingStatusCommand(
            obj.BookingId,
            obj.Status,
            obj.StatusTime,
            obj.CreateBy,
            obj.CreateTime,
            obj.Description
        ));
        return result;
    }

    [HttpPut]
    public async Task<int> Update(UpdateBookingStatusRequest obj)
    {
        var result = await mediator.Send(new UpdateBookingStatusCommand(
            obj.Id,
            obj.BookingId,
            obj.Status,
            obj.StatusTime,
            obj.UpdateBy,
            obj.UpdateTime,
            obj.Description
        ));
        return result;
    }

    [HttpDelete]
    public async Task<int> DeleteUser(Guid id)
    {
        return await mediator.Send(new DeleteBookingStatusCommand() { Id = id });
    }
}
