using MediatR;
using ErrorOr;
using RailwayReservation.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Authentication.Common;

namespace RailwayReservation.Application.Authentication.Queries;
public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;