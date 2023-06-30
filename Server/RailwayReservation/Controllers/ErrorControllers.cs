﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RailwayReservation.Api.Controllers;

[Route("error")]
[ApiController]
public class ErrorControllers : ControllerBase
{
    //[Route("error")]
    [HttpGet]
    public IActionResult Error( )
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
        return Problem(
            title: exception.Message,
            statusCode: 400
            );
    }
}
