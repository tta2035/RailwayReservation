using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Application.Services.Authentication;
using RailwayReservation.Contract.Authentication;

namespace RailwayReservation.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _auth;

        public AuthenticationController(IAuthenticationService authenticationService) { 
            _auth = authenticationService;
        }

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
        }
    }
}
