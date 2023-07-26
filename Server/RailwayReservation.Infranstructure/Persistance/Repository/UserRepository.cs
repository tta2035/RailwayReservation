using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Domain.User;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class UserRepository : GenericRepository<User, UserDto>, IUserRepository {
        private List<User> _users;
        private List<UserDto> _userDto;
        private readonly IPasswordHasing _passwordHasing;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserRepository(RailwayReservationDbContext context,
            IPasswordHasing passwordHasing,
            IJwtTokenGenerator jwtTokenGenerator) : base(context)
        {
            _users = new List<User>();
            _userDto = new List<UserDto>();
            _passwordHasing = passwordHasing;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<UserDto> Authentication(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null) return null;
            if(!_passwordHasing.VerifyPassword(password, user.Password))
            {
                throw new Exception("Password is Incorrect");
            }
            var FullName = user.FirstName + " " + user.LastName;
            user.Token = _jwtTokenGenerator.GenerateToken(user.Id, FullName);
            await _context.SaveChangesAsync();
            var result = new UserDto(user);
            return result;
        }

        public override async Task<List<UserDto>> GetAll()
        {
            _users = await base.table.ToListAsync();
            foreach (var user in _users)
            {
                _userDto.Add(new UserDto(user));
            }
            return _userDto;
        }

        public override async Task<User?> getById(Guid id)
        {
            try
            {
                var s = await base.table.FirstOrDefaultAsync(t => t.Id == id);
                return s;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy user " + ex.Message);
            }
        }
    }
}
