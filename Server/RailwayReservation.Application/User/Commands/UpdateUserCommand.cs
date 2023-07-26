using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Domain.User;

namespace RailwayReservation.Application.User.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Token { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdateUserCommand(
            Guid id,
            string userName,
            string email,
            string password,
            string firstName,
            string lastName,
            string? token,
            Guid? updateBy,
            DateTime? updateTime
        )
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Token = token;
            UpdateBy = updateBy;
            UpdateTime = DateTime.UtcNow;
        }
    }
}
