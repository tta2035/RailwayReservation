using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Domain.User;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class UserRepository : GenericRepository<User, UserDto>, IUserRepository {
        private List<User> _users;
        private List<UserDto> _userDto;

        public UserRepository(RailwayReservationDbContext context) : base(context)
        {
            _users = new List<User>();
            _userDto = new List<UserDto>();
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
