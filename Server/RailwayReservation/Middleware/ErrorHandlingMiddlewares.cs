using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RailwayReservation.Middleware;

public class ErrorHandlingMiddlewares 
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddlewares(RequestDelegate next) {
        _next = next;
    }

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } catch(Exception ex) {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex) {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonConvert.SerializeObject( new { error = ex.Message});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
 }
