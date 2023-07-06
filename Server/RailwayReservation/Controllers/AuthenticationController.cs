using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.DTOs;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Services.Authentication;
using RailwayReservation.Contract.Authentication;
using RailwayReservation.Domain.Passenger;
using System;

namespace RailwayReservation.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _auth;
        private readonly IPassengerRepository _repo;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IPassengerRepository passengerRepository
        )
        {
            _auth = authenticationService;
            _repo = passengerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(Guid id)
        {
            var respone = await _repo.getById(id);
            if (respone is null)
            {
                return NotFound();
            }
            return Ok(respone);
        }

        [HttpPost("regiter")]
        public async Task<IActionResult> Register(PassengerDto request)
        {
            var response = _auth.Register(request).Result;
            var test = response.Id;
            
            try
            {
                var result = _repo.Insert(response);
                return Ok(result);
                /*
                int i = await _repo.CheckSaveChangesAsync();
                if(i > 0)
                {
                    response = _repo.getById(response.Id);
                    return Ok(response);
                    
                }
                return BadRequest(new
                {
                    Message = "Không thêm được"
                });
                */
            }
            catch (Exception ex) {
                return BadRequest(new
                {
                    Message = ex.InnerException?.Message
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            try
            {
                var respone = _auth.login(request);
                return Ok(respone);
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.InnerException?.Message
                });
            }
        }
    }
}
