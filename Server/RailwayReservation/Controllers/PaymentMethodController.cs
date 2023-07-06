using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.PaymentMethod.Commands;
using RailwayReservation.Application.PaymentMethod.DTO;
using RailwayReservation.Application.PaymentMethod.Queries;
using RailwayReservation.Domain.PaymentMethod;

namespace RailwayReservation.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    private readonly IMediator mediator;

    public PaymentMethodController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<PaymentMethodResponse>> GetPaymentMethodList()
    {
        var query = new GetPaymentMethodListQuery();
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
    public async Task<PaymentMethodResponse> GetByTicketId(Guid id)
    {
        var result = await mediator.Send(new GetPaymentMethodByIdQuery() { Id = id });
        return result;
    }

    [HttpPost("add")]
    public async Task<PaymentMethod> Add(CreatePaymentMethodRequest obj)
    {
        var result = await mediator.Send(new CreatePaymentMethodCommand(
            obj.PaymentMethodName,
            obj.Description,
            obj.CreateBy,
            obj.CreateTime
        ));
        return result;
    }

    [HttpPut("update")]
    public async Task<int> Update(UpdatePaymentMethodRequest obj)
    {
        var result = await mediator.Send(new UpdatePaymentMethodCommand(
            obj.Id,
            obj.PaymentMethodName,
            obj.Description,
            obj.UpdateBy,
            obj.UpdateTime
        ));
        return result;
    }

    [HttpDelete("delete")]
    public async Task<int> Delete(Guid id)
    {
        return await mediator.Send(new DeletePaymentMethodCommand() { Id = id });
    }
}
