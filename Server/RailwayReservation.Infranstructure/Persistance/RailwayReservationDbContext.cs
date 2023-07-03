using System;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Domain.BookingTicket;
using RailwayReservation.Domain.Booking;
using RailwayReservation.Domain.GroupUser;
using RailwayReservation.Domain.Coach;
using RailwayReservation.Domain.GroupFunction;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.Route;
using RailwayReservation.Domain.Seat;
using RailwayReservation.Domain.SeatType;
using RailwayReservation.Domain.Station;
using RailwayReservation.Domain.Ticket;
using RailwayReservation.Domain.Train;
using RailwayReservation.Domain.User;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Infranstructure.Persistance.Interceptors;
using RailwayReservation.Domain.Passenger;
using Microsoft.Extensions.Configuration;

namespace RailwayReservation.Infranstructure.Persistance;

public sealed class RailwayReservationDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public RailwayReservationDbContext(
        IConfiguration configuration,
        DbContextOptions options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor
    )
        : base(options)
    {
        _configuration = configuration;
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }


    public RailwayReservationDbContext()
    {
    }

    public DbSet<Domain.Booking.Booking> Bookings { get; set; } = null!;

    public DbSet<Domain.BookingTicket.BookingTicket> BookingTickets { get; set; } = null!;

    public DbSet<Domain.Coach.Coach> Coaches { get; set; } = null!;

    public DbSet<Domain.Function.Function> Functions { get; set; } = null!;

    public DbSet<Domain.Group.Group> Groups { get; set; } = null!;

    public DbSet<GroupFunction> GroupFunctions { get; set; } = null!;

    public DbSet<GroupUser> GroupUsers { get; set; } = null!;

    public DbSet<Passenger> Passengers { get; set; } = null!;

    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

    public DbSet<Route> Routes { get; set; } = null!;

    public DbSet<Seat> Seats { get; set; } = null!;

    public DbSet<SeatType> SeatTypes { get; set; } = null!;

    public DbSet<Station> Stations { get; set; } = null!;

    public DbSet<Ticket> Tickets { get; set; } = null!;

    public DbSet<Train> Trains { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(RailwayReservationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbContext"));
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
