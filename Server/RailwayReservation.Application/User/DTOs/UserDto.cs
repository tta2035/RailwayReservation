using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Application.User.DTOs
{
    public class UserDto
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

        public UserDto(Domain.User.User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Token = user.Token;
            UpdateBy = user.UpdateBy;
            UpdateTime = user.UpdateTime;
        }

        public UserDto(
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
            UpdateTime = updateTime;
        }
    }
}
