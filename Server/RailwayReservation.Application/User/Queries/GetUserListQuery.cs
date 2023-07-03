using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RailwayReservation.Application.User.DTOs;

namespace RailwayReservation.Application.User.Queries;

public class GetUserListQuery : IRequest<List<UserDto>> { }
