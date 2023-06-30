using Microsoft.EntityFrameworkCore;
using RailwayReservation.Domain.BookingTicket;
using RailwayReservation.Domain.Booking;
using RailwayReservation.Domain.Function;
using RailwayReservation.Domain.Group;
using RailwayReservation.Domain.GroupUser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using RailwayReservation.Domain.Coach;
using RailwayReservation.Domain.GroupFunction;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.Refund;
using RailwayReservation.Domain.Route;
using RailwayReservation.Domain.Seat;
using RailwayReservation.Domain.SeatType;
using RailwayReservation.Domain.Station;
using RailwayReservation.Domain.Ticket;
using RailwayReservation.Domain.Train;
using RailwayReservation.Domain.User;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Infranstructure.Persistance.Interceptors;
using RailwayReservation.Infranstructure.Configurations;
using RailwayReservation.Domain.Passenger;
using RailwayReservation.Domain.Station.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Group.ValueObjects;
using RailwayReservation.Domain.Function.ValueObjects;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.SeatType.ValueObjects;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.Coach.ValueObjects;
using RailwayReservation.Domain.Seat.ValueObjects;
using RailwayReservation.Domain.Ticket.ValueObjects;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Refund.ValueObjects;

namespace RailwayReservation.Infranstructure.Persistance;

public sealed class RailwayReservationDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public RailwayReservationDbContext(
        DbContextOptions options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor
    )
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Booking> Bookings { get; set; } = null!;

    public DbSet<BookingTicket> BookingTickets { get; set; } = null!;

    public DbSet<Coach> Coaches { get; set; } = null!;

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
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
