using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Authentication.Queries;
using RailwayReservation.Application.Services.Authentication;
using RailwayReservation.Contract.Authentication;
using RailwayReservation.Domain.Common.Errors;

namespace RailwayReservation.Api.Controllers;

[AllowAnonymous]
[Route("auth")]
//[ApiController]
public class AuthenticationController : ControllerBase
{
    //private readonly ISender _mediator;
    //private readonly IMapper _mapper;
    private readonly IAuthenticationService _auth;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _auth = authenticationService;
    }

    //public AuthenticationController(ISender mediator, IMapper mapper)
    //{
    //    _mediator = mediator;
    //    _mapper = mapper;
    //}

    [HttpPost("regiter")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        
        var authResult = _auth.Register(
            request.FullName,
            request.Dob,
            request.Genger,
            request.Email,
            request.PhoneNo,
            request.Password,
            request.Address
            );

        // map sang response
        var response = new AuthenticationResponse(
           authResult.passenger.Id.Value,
           authResult.passenger.FullName,
           authResult.passenger.Dob,
           authResult.passenger.Genger,
           authResult.passenger.Email,
           authResult.passenger.PhoneNo,
           authResult.passenger.Password,
           authResult.passenger.Address,
           authResult.token,
           authResult.passenger.Description,
           authResult.passenger.CreateBy is not null ? authResult.passenger.CreateBy.Value : null,
           authResult.passenger.CreateTime,
           authResult.passenger.UpdateBy is not null ? authResult.passenger.UpdateBy.Value : null,
           authResult.passenger.UpdateTime
           );
        return Ok(response);
        
    }

    [HttpPost("login")]
    //[Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        
        var authResult = _auth.Login(
            request.Email,
            request.Password
            );

        // map sang response
        //var response = new AuthenticationResponse(
        //    authResult.PassengerId,
        //    authResult.FullName,
        //    authResult.Dob,
        //    authResult.Genger,
        //    authResult.Email,
        //    authResult.PhoneNo,
        //    authResult.Password,
        //    authResult.Address,
        //    authResult.Token,
        //    "",
        //    0,
        //    new DateTime(),
        //    0,
        //    new DateTime()
        //    );
        return Ok(authResult);
        

        //var query = _mapper.Map<LoginQuery>(request);
        //var authenticationResult = await _mediator.Send(query);

        //if (authenticationResult.IsError && authenticationResult.FirstError == Errors.Authentication.InvalidCredentials)
        //{
        //    return Problem(
        //        statusCode: StatusCodes.Status401Unauthorized,
        //        title: authenticationResult.FirstError.Description);
        //}

        //return authenticationResult.Match(
        //    authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
        //    errors => Problem(errors.ToString()));
    }
}
