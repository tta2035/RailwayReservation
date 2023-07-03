using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.User;
using RailwayReservation.Application.User.DTOs;

namespace RailwayReservation.Application.Common.Interfaces.Persistences;

public interface IUserRepository : IGenericRepository<Domain.User.User, UserDto> { 
    
}
