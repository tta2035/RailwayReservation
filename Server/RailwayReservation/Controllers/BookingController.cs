using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Booking.Commands;
using RailwayReservation.Application.Booking.DTO;
using RailwayReservation.Application.Booking.Queries;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IMediator mediator;

    public BookingController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<BookingResponse>> GetBookingList()
    {
        var Bookings = new List<BookingResponse>();
        var query = new GetBookingListQuery();
        if (query is null)
        {
            throw new Exception("query is null");
        }
        Bookings = await mediator.Send(query);
        //if (Bookings is null) throw new Exception("không có giá trị trả về");
        return Bookings;
    }

    [HttpGet("id")]
    public async Task<BookingResponse> GetBookingId(Guid id)
    {
        var Booking = await mediator.Send(new GetBookingByIdQuery() { Id = id });
        return Booking;
    }

    [HttpPost]
    public async Task<Domain.Booking.Booking> AddRoute(BookingRequest obj)
    {
        var BookingSend = await mediator.Send(
            new CreateBookingCommand(
                obj.PassengerId,
                obj.UserId,
                obj.TotalFare,
                obj.TotalPayment,
                obj.Status,
                obj.Description,
                obj.PaymentTerm,
                obj.PaymentMethodId,
                obj.CreateBy,
                DateTime.UtcNow,
                DateTime.UtcNow
            )
        );
        return BookingSend;
    }

    [HttpPut]
    public async Task<int> UpdateBooking(BookingRequest obj)
    {
        var result = await mediator.Send(
            new UpdateBookingCommand(
                obj.BookingId,
                obj.PassengerId,
                obj.TotalFare,
                obj.TotalPayment,
                obj.Status,
                obj.PaymentTerm,
                obj.PaymentMethodId,
                obj.CancellationTime,
                obj.CancellationFee,
                obj.CancellationReason,
                obj.Description,
                obj.CreateBy,
                obj.CreateTime,
                obj.UpdateBy,
                DateTime.UtcNow,
                obj.BookingTime,
                obj.UserId,
                obj.PaidAmount,
                obj.PaidTime,
                obj.RefundAmount,
                obj.RefundTime
            )
        );
        return result;
    }

    [HttpDelete]
    public async Task<int> DeleteBooking(Guid id)
    {
        return await mediator.Send(new DeleteBookingCommand() { Id = id });
    }
}
