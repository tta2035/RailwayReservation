using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Application.Common.Services;
using RailwayReservation.Application.Services.Authentication;
using RailwayReservation.Infranstructure.Authentication;
using RailwayReservation.Infranstructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Infranstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Infranstructure.Persistance.Interceptors;
using MediatR;

namespace RailwayReservation.Infranstructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfanstructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.AddPersistance();

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<RailwayReservationDbContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RailwayTest;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

        });
        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IPublisher, Mediator>();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services,
        IConfiguration configuration)
    {

        return services;
    }
}
