using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.BookingTicket.Commands;
using RailwayReservation.Application.BookingTicket.DTO;
using RailwayReservation.Application.BookingTicket.Queries;
using RailwayReservation.Domain.BookingTicket;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class BookingTicketController : ControllerBase
{
    private readonly IMediator mediator;

    public BookingTicketController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<BookingTicketResponse>> GetBookingTicketList()
    {
        var query = new GetBookingTicketListQuery();
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

    [HttpGet("get-by-ticket/id")]
    public async Task<List<BookingTicketResponse>> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetBookingTicketByTicketQuery() { TicketId = id });
        return result;
    }

    [HttpGet("get-by-booking/id")]
    public async Task<List<BookingTicketResponse>> GetBybookingId(Guid id)
    {
        var result = await mediator.Send(new GetBookingTicketByBookingQuery() { bookingId = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<BookingTicket> Add(CreateBookingTicketRequest obj)
    {
        var result = await mediator.Send(new CreateBookingTicketCommand(
            obj.BookingId,
            obj.TicketId,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdateBookingTicketRequest obj)
    {
        var result = await mediator.Send(new UpdateBookingTicketCommand(
            obj.BookingId,
            obj.TicketId,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> DeleteUser(Guid id)
    {
        return await mediator.Send(new DeleteBookingTicketCommand() { BookingId = id });
    }
}
