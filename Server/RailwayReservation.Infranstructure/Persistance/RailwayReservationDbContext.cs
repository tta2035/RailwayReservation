using Microsoft.EntityFrameworkCore;
using RailwayReservation.Domain.BankingPassenger;
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
using RailwayReservation.Domain.Paid;
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
using RailwayReservation.Domain.BankingPassenger.ValueObjects;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Paid.ValueObjects;
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

    public DbSet<BankingPassenger> BankingPassengers { get; set; } = null!;

    public DbSet<Booking> Bookings { get; set; } = null!;

    public DbSet<BookingTicket> BookingTickets { get; set; } = null!;

    public DbSet<Coach> Coaches { get; set; } = null!;

    public DbSet<Domain.Function.Function> Functions { get; set; } = null!;

    public DbSet<Domain.Group.Group> Groups { get; set; } = null!;

    public DbSet<GroupFunction> GroupFunctions { get; set; } = null!;

    public DbSet<GroupUser> GroupUsers { get; set; } = null!;

    public DbSet<Paid> Paids { get; set; } = null!;

    public DbSet<Passenger> Passengers { get; set; } = null!;

    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

    public DbSet<Refund> Refunds { get; set; } = null!;

    public DbSet<Route> Routes { get; set; } = null!;

    public DbSet<Seat> Seats { get; set; } = null!;

    public DbSet<SeatType> SeatTypes { get; set; } = null!;

    public DbSet<Station> Stations { get; set; } = null!;

    public DbSet<Ticket> Tickets { get; set; } = null!;

    public DbSet<Train> Trains { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        modelBuilder.Entity<Station>().ToTable("Station");
        modelBuilder.Entity<Route>().ToTable("Route");

        modelBuilder.Entity<Station>().HasIndex(e => e.StationName, "IX_Station_1").IsUnique();

        modelBuilder
            .Entity<Station>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => StationId.Create(value))
            .HasColumnName("StationID");
        modelBuilder.Entity<Station>().HasKey(e => e.Id);

        // builder.Property(e => e.StationId).HasColumnName("StationID");
        modelBuilder
            .Entity<Station>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder
            .Entity<Station>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Station>().Property(e => e.StationName).HasMaxLength(50);
        modelBuilder
            .Entity<Station>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder
            .Entity<Station>()
            .Property(e => e.UpdateTime)
            .HasColumnType("datetime")
            .HasColumnName("updateTime");

        modelBuilder.Entity<Route>().HasIndex(e => e.RouteName, "IX_Route_1").IsUnique();

        modelBuilder
            .Entity<Route>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => RouteId.Create(value))
            .HasColumnName("RouteID");
        modelBuilder.Entity<Route>().HasKey(e => e.Id);

        // builder.Property(e => e.RouteId).HasColumnName("RouteID");
        modelBuilder
            .Entity<Route>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder
            .Entity<Route>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Route>().Property(e => e.RouteFare).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<Route>().Property(e => e.RouteName).HasMaxLength(50);
        modelBuilder
            .Entity<Route>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder
            .Entity<Route>()
            .Property(e => e.UpdateTime)
            .HasColumnType("datetime")
            .HasColumnName("updateTime");

        modelBuilder
            .Entity<Route>()
            .Property(e => e.DepartureStation)
            .HasConversion(id => id.Value, value => StationId.Create(value))
            .HasColumnName("DepartureStation");
        modelBuilder
            .Entity<Route>()
            .HasOne(d => d.DepartureStationNavigation)
            .WithMany(p => p.RouteDepartureStationNavigations)
            .HasForeignKey(d => d.DepartureStation)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Route_Station");

        modelBuilder
            .Entity<Route>()
            .Property(e => e.DestinationStation)
            .HasConversion(id => id.Value, value => StationId.Create(value))
            .HasColumnName("DestinationStation");
        modelBuilder
            .Entity<Route>()
            .HasOne(d => d.DestinationStationNavigation)
            .WithMany(p => p.RouteDestinationStationNavigations)
            .HasForeignKey(d => d.DestinationStation)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Route_Destination_Station");

        // User
        // modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.Entity<User>().ToTable("User");

        modelBuilder
            .Entity<User>()
            .HasIndex(e => new { e.Email, e.UserName }, "IX_User_1")
            .IsUnique();

        modelBuilder.Entity<User>().HasKey(e => e.Id);
        modelBuilder
            .Entity<User>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("UserID");

        // builder.Property(e => e.UserId).HasColumnName("UserID");
        modelBuilder
            .Entity<User>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder
            .Entity<User>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<User>().Property(e => e.Email).HasMaxLength(50);
        modelBuilder.Entity<User>().Property(e => e.FirstName).HasMaxLength(50);
        modelBuilder.Entity<User>().Property(e => e.LastName).HasMaxLength(50);
        modelBuilder.Entity<User>().Property(e => e.Password).HasMaxLength(50);
        modelBuilder.Entity<User>().Property(e => e.Token).HasColumnName("token");
        modelBuilder
            .Entity<User>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder
            .Entity<User>()
            .Property(e => e.UpdateTime)
            .HasColumnType("datetime")
            .HasColumnName("updateTime");
        modelBuilder.Entity<User>().Property(e => e.UserName).HasMaxLength(50);

        
        // modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.Entity<Domain.Group.Group>().ToTable("Group");

        modelBuilder.Entity<Domain.Group.Group>().HasIndex(e => e.GroupName, "IX_Group_1").IsUnique();

        modelBuilder.Entity<Domain.Group.Group>().HasKey(e => e.Id);
        modelBuilder.Entity<Domain.Group.Group>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => GroupId.Create(value))
            .HasColumnName("GroupID");
        // builder.Property(e => e.GroupId).HasColumnName("GroupID");
        modelBuilder.Entity<Domain.Group.Group>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Domain.Group.Group>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Domain.Group.Group>().Property(e => e.GroupName).HasMaxLength(50);
        modelBuilder.Entity<Domain.Group.Group>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Domain.Group.Group>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // modelBuilder.ApplyConfiguration(new FunctionConfiguration());
        modelBuilder.Entity<Domain.Function.Function>().ToTable("Function");

        modelBuilder.Entity<Domain.Function.Function>().HasIndex(e => e.FunctionName, "IX_Function_1").IsUnique();

        modelBuilder.Entity<Domain.Function.Function>().HasKey(e => e.Id);
        modelBuilder.Entity<Domain.Function.Function>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => FunctionId.Create(value))
            .HasColumnName("FunctionID");
        // builder.Property(e => e.FunctionId).HasColumnName("FunctionID");
        modelBuilder.Entity<Domain.Function.Function>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Domain.Function.Function>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Domain.Function.Function>().Property(e => e.FunctionName).HasMaxLength(50);
        modelBuilder.Entity<Domain.Function.Function>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Domain.Function.Function>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    
        // modelBuilder.ApplyConfiguration(new GroupFunctionConfiguration());
        modelBuilder.Entity<GroupFunction>().HasKey(e => new { e.GroupId, e.FunctionId });
        modelBuilder.Entity<GroupFunction>().ToTable("GroupFunction");

        modelBuilder.Entity<GroupFunction>().HasKey(e => e.GroupId);
        modelBuilder.Entity<GroupFunction>().HasKey(e => e.FunctionId);

        modelBuilder.Entity<GroupFunction>()
            .Property(e => e.GroupId)
            .HasConversion(id => id.Value, value => GroupId.Create(value))
            .HasColumnName("GroupID");
        modelBuilder.Entity<GroupFunction>()
            .Property(e => e.FunctionId)
            .HasConversion(id => id.Value, value => FunctionId.Create(value))
            .HasColumnName("FunctionID");
        modelBuilder.Entity<GroupFunction>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<GroupFunction>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<GroupFunction>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<GroupFunction>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<GroupFunction>()
            .HasOne(d => d.Function)
            .WithMany(p => p.GroupFunctions)
            .HasForeignKey(d => d.FunctionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupFunction_Function");

        modelBuilder.Entity<GroupFunction>()
            .HasOne(d => d.Group)
            .WithMany(p => p.GroupFunctions)
            .HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupFunction_Group");

        // modelBuilder.ApplyConfiguration(new GroupUserConfiguration());
        modelBuilder.Entity<GroupUser>().HasKey(e => new { e.GroupId, e.UserId });
        modelBuilder.Entity<GroupUser>().ToTable("GroupUser");

        modelBuilder.Entity<GroupUser>().HasKey(e => e.GroupId);
        modelBuilder.Entity<GroupUser>().HasKey(e => e.UserId);

        modelBuilder.Entity<GroupUser>()
            .Property(e => e.GroupId)
            .HasConversion(id => id.Value, value => GroupId.Create(value))
            .HasColumnName("GroupID");
        modelBuilder.Entity<GroupUser>()
            .Property(e => e.UserId)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("UserID");
        modelBuilder.Entity<GroupUser>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<GroupUser>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<GroupUser>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<GroupUser>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<GroupUser>()
            .HasOne(d => d.Group)
            .WithMany(p => p.GroupUsers)
            .HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupUser_Group");

        modelBuilder.Entity<GroupUser>()
            .HasOne(d => d.User)
            .WithMany(p => p.GroupUsers)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupUser_User");
    

        // modelBuilder.ApplyConfiguration(new PassengerConfiguration());
        modelBuilder.Entity<Passenger>().ToTable("Passenger").HasKey(d => d.Id);
        modelBuilder.Entity<Passenger>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => PassengerId.Create(value))
            .HasColumnName("PassengerID");

        modelBuilder.Entity<Passenger>().HasIndex(e => new { e.Email, e.PhoneNo }, "IX_Passenger_1").IsUnique();

        modelBuilder.Entity<Passenger>().Property(e => e.Address).HasMaxLength(150);
        modelBuilder.Entity<Passenger>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Passenger>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Passenger>().Property(e => e.Dob).HasColumnType("date");
        modelBuilder.Entity<Passenger>().Property(e => e.Email).HasMaxLength(50);
        modelBuilder.Entity<Passenger>().Property(e => e.FullName).HasMaxLength(50);
        modelBuilder.Entity<Passenger>().Property(e => e.Genger).HasMaxLength(50);
        modelBuilder.Entity<Passenger>().Property(e => e.Image).HasMaxLength(50);
        modelBuilder.Entity<Passenger>().Property(e => e.Password).HasMaxLength(100);
        modelBuilder.Entity<Passenger>().Property(e => e.PhoneNo).HasMaxLength(10);
        modelBuilder.Entity<Passenger>().Property(e => e.Token).HasMaxLength(50).HasColumnName("token");
        modelBuilder.Entity<Passenger>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Passenger>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // modelBuilder.ApplyConfiguration(new SeatTypeConfiguration());
        modelBuilder.Entity<SeatType>().ToTable("SeatType");

        modelBuilder.Entity<SeatType>().HasIndex(e => e.SeatTypeName, "IX_SeatType_1").IsUnique();

        modelBuilder.Entity<SeatType>().HasKey(e => e.Id);
        modelBuilder.Entity<SeatType>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => SeatTypeId.Create(value))
            .HasColumnName("SeatTypeID");
        // builder.Property(e => e.SeatTypeId).ValueGeneratedNever().HasColumnName("SeatTypeID");
        modelBuilder.Entity<SeatType>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<SeatType>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<SeatType>().Property(e => e.RaitoFare).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<SeatType>().Property(e => e.SeatTypeName).HasMaxLength(50);
        modelBuilder.Entity<SeatType>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<SeatType>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
        modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");

        modelBuilder.Entity<PaymentMethod>().HasIndex(e => e.PaymentMethodName, "IX_PaymentMethod_1").IsUnique();

        modelBuilder.Entity<PaymentMethod>().HasKey(e => e.Id);
        modelBuilder.Entity<PaymentMethod>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => PaymentMethodId.Create(value))
            .HasColumnName("PaymentMethodID");

        modelBuilder.Entity<PaymentMethod>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<PaymentMethod>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<PaymentMethod>().Property(e => e.PaymentMethodName).HasMaxLength(50);
        modelBuilder.Entity<PaymentMethod>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<PaymentMethod>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // modelBuilder.ApplyConfiguration(new StationConfiguration());
        // modelBuilder.ApplyConfiguration(new RouteConfiguration());

        // modelBuilder.ApplyConfiguration(new TrainConfiguration());
        modelBuilder.Entity<Train>().ToTable("Train");

        modelBuilder.Entity<Train>().HasIndex(e => e.TrainName, "IX_Train_1").IsUnique();

        modelBuilder.Entity<Train>().HasKey(e => e.Id);
        modelBuilder.Entity<Train>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => TrainId.Create(value))
            .HasColumnName("TrainID");

        // builder.Property(e => e.TrainId).HasColumnName("TrainID");
        modelBuilder.Entity<Train>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Train>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Train>().Property(e => e.TrainName).HasMaxLength(50);
        modelBuilder.Entity<Train>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Train>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // modelBuilder.ApplyConfiguration(new CoachConfiguration());
        modelBuilder.Entity<Coach>().ToTable("Coach");

        modelBuilder.Entity<Coach>().HasIndex(e => e.CoachNo, "IX_Coach").IsUnique();

        modelBuilder.Entity<Coach>().HasKey(e => e.Id);
        modelBuilder.Entity<Coach>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => CoachId.Create(value))
            .HasColumnName("CoachID");

        // builder.Property(e => e.CoachId).HasColumnName("CoachID");
        modelBuilder.Entity<Coach>().Property(e => e.CoachNo).HasMaxLength(50);
        modelBuilder.Entity<Coach>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Coach>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Coach>()
            .Property(e => e.TrainId)
            .HasConversion(id => id.Value, value => TrainId.Create(value))
            .HasColumnName("TrainID");
        modelBuilder.Entity<Coach>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Coach>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<Coach>()
            .HasOne(d => d.Train)
            .WithMany(p => p.Coaches)
            .HasForeignKey(d => d.TrainId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Coach_Train");

        // modelBuilder.ApplyConfiguration(new SeatConfiguration());
        modelBuilder.Entity<Seat>().ToTable("Seat");

        modelBuilder.Entity<Seat>().HasIndex(e => e.SeatNo, "IX_Seat_1").IsUnique();

        modelBuilder.Entity<Seat>().HasKey(e => e.Id);
        modelBuilder.Entity<Seat>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => SeatId.Create(value))
            .HasColumnName("SeatID");

        // builder.Property(e => e.SeatId).ValueGeneratedNever().HasColumnName("SeatID");
        modelBuilder.Entity<Seat>()
            .Property(e => e.CoachId)
            .HasConversion(id => id.Value, value => CoachId.Create(value))
            .HasColumnName("CoachID");
        modelBuilder.Entity<Seat>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Seat>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Seat>().Property(e => e.SeatNo).HasMaxLength(50);
        modelBuilder.Entity<Seat>()
            .Property(e => e.SeatTypeId)
            .HasConversion(id => id.Value, value => SeatTypeId.Create(value))
            .HasColumnName("SeatTypeID");
        modelBuilder.Entity<Seat>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Seat>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<Seat>()
            .HasOne(d => d.Coach)
            .WithMany(p => p.Seats)
            .HasForeignKey(d => d.CoachId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Seat_Coach");

        modelBuilder.Entity<Seat>()
            .HasOne(d => d.SeatType)
            .WithMany(p => p.Seats)
            .HasForeignKey(d => d.SeatTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Seat_SeatType");

        // modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.Entity<Ticket>().ToTable("Ticket");

        modelBuilder.Entity<Ticket>().HasKey(e => e.Id);
        modelBuilder.Entity<Ticket>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => TicketId.Create(value))
            .HasColumnName("TicketID");

        // builder.Property(e => e.TicketId).ValueGeneratedNever().HasColumnName("TicketID");
        modelBuilder.Entity<Ticket>().Property(e => e.ArriveTime).HasColumnType("datetime");
        modelBuilder.Entity<Ticket>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Ticket>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Ticket>().Property(e => e.DepartureTime).HasColumnType("datetime");
        modelBuilder.Entity<Ticket>().Property(e => e.Fare).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<Ticket>()
            .Property(e => e.RouteId)
            .HasConversion(id => id.Value, value => RouteId.Create(value))
            .HasColumnName("RouteID");
        modelBuilder.Entity<Ticket>()
            .Property(e => e.SeatId)
            .HasConversion(id => id.Value, value => SeatId.Create(value))
            .HasColumnName("SeatID");
        modelBuilder.Entity<Ticket>()
            .Property(e => e.TrainId)
            .HasConversion(id => id.Value, value => TrainId.Create(value))
            .HasColumnName("TrainID");
        modelBuilder.Entity<Ticket>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Ticket>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // modelBuilder.ApplyConfiguration(new BankingPassengerConfiguration());
        modelBuilder.Entity<BankingPassenger>().ToTable("BankingPassenger").HasKey(e => e.Id);

        modelBuilder.Entity<BankingPassenger>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => BankingPassengerId.Create(value))
            .HasColumnName("BankingPassengerID");

        modelBuilder.Entity<BankingPassenger>().HasIndex(e => e.BankAccountNumber, "IX_BankingPassenger_1").IsUnique();
        
        modelBuilder.Entity<BankingPassenger>().Property(e => e.BankAccountNumber).HasMaxLength(50);
        modelBuilder.Entity<BankingPassenger>().Property(e => e.BankName).HasMaxLength(50);
        modelBuilder.Entity<BankingPassenger>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<BankingPassenger>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<BankingPassenger>()
            .Property(e => e.PassengerId)
            .HasConversion(id => id.Value, value => PassengerId.Create(value))
            .HasColumnName("PassengerID");
        modelBuilder.Entity<BankingPassenger>()
            .Property(e => e.PaymentMethodId)
            .HasConversion(id => id.Value, value => PaymentMethodId.Create(value))
            .HasColumnName("PaymentMethodID");
        modelBuilder.Entity<BankingPassenger>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<BankingPassenger>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.Entity<Booking>().ToTable("Booking");

        modelBuilder.Entity<Booking>().HasKey(e => e.Id);
        modelBuilder.Entity<Booking>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => BookingId.Create(value))
            .HasColumnName("BookingID");

        // builder.Property(e => e.BookingId).ValueGeneratedNever().HasColumnName("BookingID");
        modelBuilder.Entity<Booking>().Property(e => e.CancellationFee).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<Booking>().Property(e => e.CancellationTime).HasColumnType("datetime");
        modelBuilder.Entity<Booking>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Booking>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");

        modelBuilder.Entity<Booking>().Property(e => e.PaymentTerm).HasColumnType("datetime");
        modelBuilder.Entity<Booking>().Property(e => e.TotalFare).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<Booking>().Property(e => e.TotalPayment).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<Booking>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Booking>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<Booking>()
            .Property(e => e.PassengerId)
            .HasConversion(id => id.Value, value => PassengerId.Create(value))
            .HasColumnName("PassengerId");
        modelBuilder.Entity<Booking>()
            .HasOne(d => d.Passenger)
            .WithMany(p => p.Bookings)
            .HasForeignKey(d => d.PassengerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Booking_Passenger");

        modelBuilder.Entity<Booking>()
            .Property(e => e.PassengerPaymentMethod)
            .HasConversion(id => id.Value, value => BankingPassengerId.Create(value))
            .HasColumnName("PassengerPaymentMethod");

        modelBuilder.Entity<Booking>()
            .HasOne(d => d.PassengerPaymentMethodNavigation)
            .WithMany(p => p.Bookings)
            .HasForeignKey(d => d.PassengerPaymentMethod)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Booking_BankingPassenger");
            
        modelBuilder.Entity<Booking>()
            .Property(e => e.DefaultPaymentMethod)
            .HasConversion(id => id.Value, value => PaymentMethodId.Create(value))
            .HasColumnName("DefaultPaymentMethod");
        modelBuilder.Entity<Booking>()
            .HasOne(d => d.DefaultPaymentMethodNavigation)
            .WithMany(p => p.Bookings)
            .HasForeignKey(d => d.DefaultPaymentMethod)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Booking_PaymentMethod");

        // modelBuilder.ApplyConfiguration(new BookingTicketConfiguration());
        modelBuilder.Entity<BookingTicket>().ToTable("BookingTicket");

        modelBuilder.Entity<BookingTicket>().HasKey(e => new { e.BookingId, e.TicketId });
        // builder
        //     .Property(e => e.BookingTicketId)
        //     .ValueGeneratedNever()
        //     .HasConversion(id => id.Value, value => BookingTicketId.Create(value))
        //     .HasColumnName("BookingTicketID");

        modelBuilder.Entity<BookingTicket>()
            .Property(e => e.BookingId)
            .HasConversion(id => id.Value, value => BookingId.Create(value))
            .HasColumnName("BookingID");

        modelBuilder.Entity<BookingTicket>()
            .Property(e => e.TicketId)
            .HasConversion(id => id.Value, value => TicketId.Create(value))
            .HasColumnName("TicketID");
        modelBuilder.Entity<BookingTicket>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<BookingTicket>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<BookingTicket>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");

        modelBuilder.Entity<BookingTicket>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<BookingTicket>()
            .HasOne(d => d.Booking)
            .WithMany(p => p.BookingTickets)
            .HasForeignKey(d => d.BookingId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookingTicket_Booking");

        modelBuilder.Entity<BookingTicket>()
            .HasOne(d => d.Ticket)
            .WithMany(p => p.BookingTickets)
            .HasForeignKey(d => d.TicketId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookingTicket_Ticket");

        // modelBuilder.ApplyConfiguration(new PaidConfiguration());
        modelBuilder.Entity<Paid>().ToTable("Paid");

        modelBuilder.Entity<Paid>().HasKey(e => e.Id);
        modelBuilder.Entity<Paid>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => PaidId.Create(value))
            .HasColumnName("PaidID");

        // builder.Property(e => e.PaidId).ValueGeneratedNever().HasColumnName("PaidID");

        modelBuilder.Entity<Paid>()
            .Property(e => e.BookingId)
            .HasConversion(id => id.Value, value => BookingId.Create(value))
            .HasColumnName("BookingID");
        modelBuilder.Entity<Paid>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Paid>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Paid>().Property(e => e.PaidAmount).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<Paid>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Paid>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<Paid>()
            .HasOne(d => d.Booking)
            .WithMany(p => p.Paids)
            .HasForeignKey(d => d.BookingId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Paid_Booking");

        // modelBuilder.ApplyConfiguration(new RefundConfiguration());
        modelBuilder.Entity<Refund>().ToTable("Refund");

        modelBuilder.Entity<Refund>().HasKey(e => e.Id);
        modelBuilder.Entity<Refund>()
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => RefundId.Create(value))
            .HasColumnName("RefundID");

        // builder.Property(e => e.RefundId).ValueGeneratedNever().HasColumnName("RefundID");
        modelBuilder.Entity<Refund>()
            .Property(e => e.BookingId)
            .HasConversion(id => id.Value, value => BookingId.Create(value))
            .HasColumnName("BookingID");
        modelBuilder.Entity<Refund>()
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        modelBuilder.Entity<Refund>()
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        modelBuilder.Entity<Refund>().Property(e => e.RefundAmount).HasColumnType("decimal(18, 0)");
        modelBuilder.Entity<Refund>()
            .Property(e => e.RefundTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        modelBuilder.Entity<Refund>()
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        modelBuilder.Entity<Refund>().Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        modelBuilder.Entity<Refund>()
            .HasOne(d => d.Booking)
            .WithMany(p => p.Refunds)
            .HasForeignKey(d => d.BookingId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Refund_Booking");
            */

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
