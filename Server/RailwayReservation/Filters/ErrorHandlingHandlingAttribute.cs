using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RailwayReservation.Api.Filters;

public class ErrorHandlingHandlingAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var errorResult = new ProblemDetails
        {
            Title = context.Exception.Message,
            Status = (int)HttpStatusCode.InternalServerError
        };
        context.Result = new ObjectResult(errorResult);
        context.ExceptionHandled = true;
    }
}
