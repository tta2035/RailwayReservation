using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RailwayReservation.Application.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RailwayReservation.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddMediatR(typeof(DependencyInjection).GetTypeInfo().Assembly);

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
