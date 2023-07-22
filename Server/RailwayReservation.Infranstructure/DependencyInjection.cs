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
using RailwayReservation.Application.BookingStatus.Handler;
using RailwayReservation.Application.BookingStatus.DTO;
using RailwayReservation.Application.BookingStatus.Commands;
using RailwayReservation.Application.BookingStatus.Queries;
using RailwayReservation.Application.BookingTicket.Handler;
using RailwayReservation.Application.BookingTicket.Commands;
using RailwayReservation.Application.BookingTicket.DTO;
using RailwayReservation.Application.BookingTicket.Queries;
using RailwayReservation.Application.Coach.Handler;
using RailwayReservation.Application.Coach.Commands;
using RailwayReservation.Application.Coach.DTO;
using RailwayReservation.Application.Coach.Queries;
using RailwayReservation.Application.Function.Handler;
using RailwayReservation.Application.Function.Commands;
using RailwayReservation.Application.Function.Queries;
using RailwayReservation.Application.Function.DTO;
using RailwayReservation.Application.Group.Handler;
using RailwayReservation.Application.Group.Commands;
using RailwayReservation.Application.Group.Queries;
using RailwayReservation.Application.Group.DTO;
using RailwayReservation.Application.GroupFunction.Handler;
using RailwayReservation.Application.GroupFunction.Commands;
using RailwayReservation.Application.GroupUser.Handler;
using RailwayReservation.Application.GroupUser.Commands;
using RailwayReservation.Application.PaymentMethod.Handler;
using RailwayReservation.Application.PaymentMethod.Commands;
using RailwayReservation.Application.PaymentMethod.Queries;
using RailwayReservation.Application.PaymentMethod.DTO;
using RailwayReservation.Application.Seat.Handler;
using RailwayReservation.Application.Seat.Commands;
using RailwayReservation.Application.Seat.Queries;
using RailwayReservation.Application.Seat.DTO;
using RailwayReservation.Application.SeatType.Handler;
using RailwayReservation.Application.SeatType.Commands;
using RailwayReservation.Application.SeatType.Queries;
using RailwayReservation.Application.SeatType.DTO;
using RailwayReservation.Application.Ticket.Handler;
using RailwayReservation.Application.Ticket.Commands;
using RailwayReservation.Application.Ticket.Queries;
using RailwayReservation.Application.Ticket.DTO;
using RailwayReservation.Application.Trip.Handler;
using RailwayReservation.Application.Trip.Commands;
using RailwayReservation.Application.Trip.Queries;
using RailwayReservation.Application.Trip.DTO;

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
        services.AddSingleton<IPasswordHasing, PasswordHasing>();
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
        services.AddScoped<ITripRepository, TripRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        // booking
        services.AddTransient<IRequestHandler<GetBookingListQuery, List<BookingResponse>>, GetBookingListHandler>();
        services.AddTransient<IRequestHandler<GetBookingByIdQuery, BookingResponse>, GetBookingByIdHandler>();
        services.AddTransient<IRequestHandler<CreateBookingCommand, Booking>, CreateBookingHandler>();
        services.AddTransient<IRequestHandler<UpdateBookingCommand, int>, UpdateBookingHandler>();
        services.AddTransient<IRequestHandler<DeleteBookingCommand, int>, DeleteBookingHandler>();

        // booking status
        services.AddTransient<IRequestHandler<CreateBookingStatusCommand, Domain.BookingStatus.BookingStatus>, CreateBookingStatusHandler>();
        services.AddTransient<IRequestHandler<DeleteBookingStatusCommand, int>, DeleteBookingStatusHandler>();
        services.AddTransient<IRequestHandler<UpdateBookingStatusCommand, int>, UpdateBookingStatusHandler>();
        services.AddTransient<IRequestHandler<GetBookingStatusByIdQuery, BookingStatusResponse>, GetBookingStatusByIdHandler>();
        services.AddTransient<IRequestHandler<GetListBookingStatusQuery, List<BookingStatusResponse>>, GetListBookingStatusHandler>();

        // booking ticket
        services.AddTransient<IRequestHandler<CreateBookingTicketCommand, Domain.BookingTicket.BookingTicket>, CreateBookingTicketHandler>();
        services.AddTransient<IRequestHandler<DeleteBookingTicketCommand, int>, DeleteBookingTicketHandler>();
        services.AddTransient<IRequestHandler<UpdateBookingTicketCommand, int>, UpdateBookingTicketHadler>();
        //services.AddTransient<IRequestHandler<GetBookingTicketByIdQuery, BookingTicketResponse>, GetBookingTicketByIdHandler>();
        services.AddTransient<IRequestHandler<GetBookingTicketByBookingQuery, List<BookingTicketResponse>>, GetBookingTicketByBookingHandler>();
        services.AddTransient<IRequestHandler<GetBookingTicketListQuery, List<BookingTicketResponse>>, GetBookingTicketListHadler>();

        // coach
        services.AddTransient<IRequestHandler<CreateCoachCommand, Domain.Coach.Coach>, CreateCoachHandler>();
        services.AddTransient<IRequestHandler<DeleteCoachCommand, int>, DeleteCoachHandler>();
        services.AddTransient<IRequestHandler<UpdateCoachCommand, int>, UpdateCoachHadler>();
        services.AddTransient<IRequestHandler<GetCoachByIdQuery, CoachResponse>, GetCoachByIdHadler>();
        services.AddTransient<IRequestHandler<GetCoachByTrainIdQuery, List<CoachResponse>>, GetCoachByTrainIdHandler>();
        services.AddTransient<IRequestHandler<GetCoachListQuery, List<CoachResponse>>, GetCoachListHandler>();

        // function
        services.AddTransient<IRequestHandler<CreateFunctionCommand, Domain.Function.Function>, CreateFunctionHandler>();
        services.AddTransient<IRequestHandler<DeleteFunctionCommand, int>, DeleteFunctionHandler>();
        services.AddTransient<IRequestHandler<UpdateFunctionCommand, int>, UpdateFunctionHandler>();
        services.AddTransient<IRequestHandler<GetFunctionByIdQuery, FunctionResponse>, GetFunctionByIdHandler>();
        services.AddTransient<IRequestHandler<GetFunctionListQuery, List<FunctionResponse>>, GetFunctionListHandler>();
        //services.AddTransient<IRequestHandler<GetCoachListQuery, List<FunctionResponse>>, GetCoachListHandler>();

        // group
        services.AddTransient<IRequestHandler<CreateGroupCommand, Domain.Group.Group>, CreateGroupHandler>();
        services.AddTransient<IRequestHandler<DeleteGroupCommand, int>, DeleteGroupHandler>();
        services.AddTransient<IRequestHandler<UpdateGroupCommand, int>, UpdateGroupHandler>();
        services.AddTransient<IRequestHandler<GetGroupByIdQuery, GroupResponse>, GetGroupByIdHandler>();
        services.AddTransient<IRequestHandler<GetGroupListQuery, List<GroupResponse>>, GetGroupListHandler>();

        // groupfunction
        services.AddTransient<IRequestHandler<CreateGroupFunctionCommand, Domain.GroupFunction.GroupFunction>, CreateGroupFunctionHandler>();
        services.AddTransient<IRequestHandler<DeleteGroupFunctionCommand, int>, DeleteGroupFunctionHandler>();
        services.AddTransient<IRequestHandler<UpdateGroupFunctionCommand, int>, UpdateGroupFunctionHandler>();

        // group user
        services.AddTransient<IRequestHandler<CreateGroupUserCommand, Domain.GroupUser.GroupUser>, CreateGroupUserHandler>();
        services.AddTransient<IRequestHandler<DeleteGroupUserCommand, int>, DeleteGroupUserHandler>();
        services.AddTransient<IRequestHandler<UpdateGroupUserCommand, int>, UpdateGroupUserHandler>();

        // payment method
        services.AddTransient<IRequestHandler<CreatePaymentMethodCommand, Domain.PaymentMethod.PaymentMethod>, CreatePaymentMethodHandler>();
        services.AddTransient<IRequestHandler<DeletePaymentMethodCommand, int>, DeletePaymentMethodHandler>();
        services.AddTransient<IRequestHandler<UpdatePaymentMethodCommand, int>, UpdatePaymentMethodHandler>();
        services.AddTransient<IRequestHandler<GetPaymentMethodByIdQuery, PaymentMethodResponse>, GetPaymentMethodByIdHandler>();
        services.AddTransient<IRequestHandler<GetPaymentMethodListQuery, List<PaymentMethodResponse>>, GetPaymentMethodListHandler>();

        // route
        services.AddTransient<IRequestHandler<GetRouteListQuery, List<RouteResponse>>, GetRouteListHandler>();
        services.AddTransient<IRequestHandler<GetRouteByIdQuery, RouteResponse>, GetRouteByIdHandler>();
        services.AddTransient<IRequestHandler<CreateRouteCommand, Route>, CreateRouteHandler>();
        services.AddTransient<IRequestHandler<UpdateRouteCommand, int>, UpdateRouteHandler>();
        services.AddTransient<IRequestHandler<DeleteRouteCommand, int>, DeleteRouteHandler>();

        // seat
        services.AddTransient<IRequestHandler<CreateSeatCommand, Domain.Seat.Seat>, CreateSeatHandler>();
        services.AddTransient<IRequestHandler<DeleteSeatCommand, int>, DeleteSeatHandler>();
        services.AddTransient<IRequestHandler<UpdateSeatCommand, int>, UpdateSeatHandler>();
        services.AddTransient<IRequestHandler<GetSeatByIdQuery, SeatResponse>, GetSeatByIdHandler>();
        services.AddTransient<IRequestHandler<GetSeatListQuery, List<SeatResponse>>, GetSeatListHandler>();

        // seat type
        services.AddTransient<IRequestHandler<CreateSeatTypeCommand, Domain.SeatType.SeatType>, CreateSeatTypeHandler>();
        services.AddTransient<IRequestHandler<DeleteSeatTypeCommand, int>, DeleteSeatTypeHandler>();
        services.AddTransient<IRequestHandler<UpdateSeatTypeCommand, int>, UpdateSeatTypeHandler>();
        services.AddTransient<IRequestHandler<GetSeatTypeByIdQuery, SeatTypeResponse>, GetSeatTypeByIdHandler>();
        services.AddTransient<IRequestHandler<GetSeatTypeByListQuery, List<SeatTypeResponse>>, GetSeatTypeByListHandler>();

        // station
        services.AddTransient<IRequestHandler<GetStationListQuery, List<StationResponse>>, GetStationListHandler>();
        services.AddTransient<IRequestHandler<GetStationByIdQuery, StationResponse>, GetStationByIdHandler>();
        services.AddTransient<IRequestHandler<CreateStationCommand, Station>, CreateStationHandler>();
        services.AddTransient<IRequestHandler<UpdateStationCommand, int>, UpdateStationHandler>();
        services.AddTransient<IRequestHandler<DeleteStationCommand, int>, DeleteStationHandler>();

        // ticket
        services.AddTransient<IRequestHandler<CreateTicketCommand, Domain.Ticket.Ticket>, CreateTicketHandler>();
        services.AddTransient<IRequestHandler<AutoCreateWhenCreateTripCommand, List<Domain.Ticket.Ticket>>, AutoCreateWhenCreateTripHandler>();
        services.AddTransient<IRequestHandler<DeleteTicketCommand, int>, DeleteTicketHandler>();
        services.AddTransient<IRequestHandler<UpdateTicketCommand, int>, UpdateTicketHandler>();
        services.AddTransient<IRequestHandler<GetTicketByIdQuery, TicketResponse>, GetTicketByIdHandler>();
        services.AddTransient<IRequestHandler<GetTicketListQuery, List<TicketResponse>>, GetTicketListHandler>();


        // train
        services.AddTransient<IRequestHandler<GetTrainListQuery, List<TrainResponse>>, GetTrainListHandler>();
        services.AddTransient<IRequestHandler<GetTrainByIdQuery, TrainResponse>, GetTrainByIdHandler>();
        services.AddTransient<IRequestHandler<CreateTrainCommand, Train>, CreateTrainHandler>();
        services.AddTransient<IRequestHandler<UpdateTrainCommand, int>, UpdateTrainHandler>();
        services.AddTransient<IRequestHandler<DeleteTrainCommand, int>, DeleteTrainHandler>();

        // trip
        services.AddTransient<IRequestHandler<CreateTripCommand, Domain.Trip.Trip>, CreateTripHandler>();
        services.AddTransient<IRequestHandler<DeleteTripCommand, int>, DeleteTripHandler>();
        services.AddTransient<IRequestHandler<UpdateTripCommand, int>, UpdateTripHandler>();
        services.AddTransient<IRequestHandler<GetTripByIdQuery, TripResponse>, GetTripByIdHandler>();
        services.AddTransient<IRequestHandler<GetTripListQuery, List<TripResponse>>, GetTripListHandler>();


        // user
        services.AddTransient<IRequestHandler<GetUserListQuery, List<UserDto>>, GetUserListHandler>();        
        services.AddTransient<IRequestHandler<GetUserByIdQuery, UserDto>, GetUserByIdHandler>();
        services.AddTransient<IRequestHandler<AuthenticationQuery, UserDto>, AuthenticationHandler>();
        services.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserHandler>();
        services.AddTransient<IRequestHandler<UpdateUserCommand, int>, UpdateUserHandler>();
        services.AddTransient<IRequestHandler<DeleteUserCommand, int>, DeleteUserHandler>();

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
