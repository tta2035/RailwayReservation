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
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Infranstructure.Persistance.Repository;
using RailwayReservation.Infranstructure.Persistance.Services;
using RailwayReservation.Application.User.Queries;
using RailwayReservation.Application.User.Handler;
using RailwayReservation.Application.User.DTOs;
using RailwayReservation.Application.User.Commands;
using RailwayReservation.Domain.User;
using RailwayReservation.Domain.Route;
using RailwayReservation.Application.Route.DTO;
using RailwayReservation.Application.Route.Queries;
using RailwayReservation.Application.Route.Handler;
using RailwayReservation.Application.Route.Commands;
using RailwayReservation.Application.Booking.DTO;
using RailwayReservation.Application.Booking.Handler;
using RailwayReservation.Application.Booking.Queries;
using RailwayReservation.Application.Booking.Commands;
using RailwayReservation.Domain.Booking;
using RailwayReservation.Application.Train.Queries;
using RailwayReservation.Application.Train.Commands;
using RailwayReservation.Application.Train.DTO;
using RailwayReservation.Domain.Train;
using RailwayReservation.Application.Train.Handler;
using RailwayReservation.Application.Station.Queries;
using RailwayReservation.Application.Station.Commands;
using RailwayReservation.Application.Station.DTO;
using RailwayReservation.Domain.Station;
using RailwayReservation.Application.Station.Handler;

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

        services.AddScoped<IPassengerRepository, PassengerRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookingStatusRepository, BookingStatusRepository>();
        services.AddScoped<IBookingTicketRepository, BookingTicketRepository>();
        services.AddScoped<ICoachRepository, CoachRepository>();
        services.AddScoped<IFunctionRepository, FunctionRepository>();
        services.AddScoped<IGroupFunctionRepository, GroupFunctionRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IGroupUserRepository, GroupUserRepository>();
        services.AddScoped<IPassengerRepository, PassengerRepository>();
        services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
        services.AddScoped<IRefundRepository, RefundRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();
        services.AddScoped<ISeatTypeRepository, SeatTypeRepository>();
        services.AddScoped<IStationRepository, StationRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ITrainRepository, TrainRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        // booking
        services.AddTransient<IRequestHandler<GetBookingListQuery, List<BookingResponse>>, GetBookingListHandler>();
        services.AddTransient<IRequestHandler<GetBookingByIdQuery, BookingResponse>, GetBookingByIdHandler>();
        services.AddTransient<IRequestHandler<CreateBookingCommand, Booking>, CreateBookingHandler>();
        services.AddTransient<IRequestHandler<UpdateBookingCommand, int>, UpdateBookingHandler>();
        services.AddTransient<IRequestHandler<DeleteBookingCommand, int>, DeleteBookingHandler>();

        services.AddTransient<IRequestHandler<GetUserListQuery, List<UserDto>>, GetUserListHandler>();        
        services.AddTransient<IRequestHandler<GetUserByIdQuery, UserDto>, GetUserByIdHandler>();
        services.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserHandler>();
        services.AddTransient<IRequestHandler<UpdateUserCommand, int>, UpdateUserHandler>();
        services.AddTransient<IRequestHandler<DeleteUserCommand, int>, DeleteUserHandler>();

        services.AddTransient<IRequestHandler<GetRouteListQuery, List<RouteResponse>>, GetRouteListHandler>();        
        services.AddTransient<IRequestHandler<GetRouteByIdQuery, RouteResponse>, GetRouteByIdHandler>();
        services.AddTransient<IRequestHandler<CreateRouteCommand, Route>, CreateRouteHandler>();
        services.AddTransient<IRequestHandler<UpdateRouteCommand, int>, UpdateRouteHandler>();
        services.AddTransient<IRequestHandler<DeleteRouteCommand, int>, DeleteRouteHandler>();

        // train
        services.AddTransient<IRequestHandler<GetTrainListQuery, List<TrainResponse>>, GetTrainListHandler>();        
        services.AddTransient<IRequestHandler<GetTrainByIdQuery, TrainResponse>, GetTrainByIdHandler>();
        services.AddTransient<IRequestHandler<CreateTrainCommand, Train>, CreateTrainHandler>();
        services.AddTransient<IRequestHandler<UpdateTrainCommand, int>, UpdateTrainHandler>();
        services.AddTransient<IRequestHandler<DeleteTrainCommand, int>, DeleteTrainHandler>();

        // station
        services.AddTransient<IRequestHandler<GetStationListQuery, List<StationResponse>>, GetStationListHandler>();
        services.AddTransient<IRequestHandler<GetStationByIdQuery, StationResponse>, GetStationByIdHandler>();
        services.AddTransient<IRequestHandler<CreateStationCommand, Station>, CreateStationHandler>();
        services.AddTransient<IRequestHandler<UpdateStationCommand, int>, UpdateStationHandler>();
        services.AddTransient<IRequestHandler<DeleteStationCommand, int>, DeleteStationHandler>();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<RailwayReservationDbContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Railway;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

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
