using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.User.DTOs;

namespace RailwayReservation.Application.User.Commands
{
    public class CreateUserCommand : IRequest<Domain.User.User>
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Token { get; set; }

        public CreateUserCommand(
            string userName,
            string email,
            string password,
            string firstName,
            string lastName,
            string? token
        )
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Token = token;
        }
    }
}
