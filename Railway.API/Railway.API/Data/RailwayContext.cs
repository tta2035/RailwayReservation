using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Railway.API.Models;

namespace Railway.API.Data;

public partial class RailwayContext : DbContext
{
    public RailwayContext()
    {
    }

    public RailwayContext(DbContextOptions<RailwayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankingPassenger> BankingPassengers { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingTicket> BookingTickets { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Function> Functions { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupFunction> GroupFunctions { get; set; }

    public virtual DbSet<GroupUser> GroupUsers { get; set; }

    public virtual DbSet<Paid> Paids { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Refund> Refunds { get; set; }

    public virtual DbSet<Railway.API.Models.Route> Routes { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatType> SeatTypes { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankingPassenger>(entity =>
        {
            entity.ToTable("BankingPassenger");

            entity.HasIndex(e => e.BankAccountNumber, "IX_BankingPassenger_1").IsUnique();

            entity.Property(e => e.BankingPassengerId)
                .ValueGeneratedNever()
                .HasColumnName("BankingPassengerID");
            entity.Property(e => e.BankAccountNumber).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Passenger).WithMany(p => p.BankingPassengers)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankingPassenger_Passenger");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.BankingPassengers)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankingPassenger_PaymentMethod1");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("BookingID");
            entity.Property(e => e.CancellationFee).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CancellationTime).HasColumnType("datetime");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.PaymentTerm).HasColumnType("datetime");
            entity.Property(e => e.TotalFare).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalPayment).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.DefaultPaymentMethodNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.DefaultPaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_PaymentMethod");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Passenger");

            entity.HasOne(d => d.PassengerPaymentMethodNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PassengerPaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_BankingPassenger");
        });

        modelBuilder.Entity<BookingTicket>(entity =>
        {
            entity.HasKey(e => new { e.BookingId, e.TicketId });

            entity.ToTable("BookingTicket");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingTickets)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingTicket_Booking");

            entity.HasOne(d => d.Ticket).WithMany(p => p.BookingTickets)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingTicket_Ticket");
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.ToTable("Coach");

            entity.HasIndex(e => e.CoachNo, "IX_Coach").IsUnique();

            entity.Property(e => e.CoachId).HasColumnName("CoachID");
            entity.Property(e => e.CoachNo).HasMaxLength(50);
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.TrainId).HasColumnName("TrainID");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Train).WithMany(p => p.Coaches)
                .HasForeignKey(d => d.TrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Coach_Train");
        });

        modelBuilder.Entity<Function>(entity =>
        {
            entity.ToTable("Function");

            entity.HasIndex(e => e.FunctionName, "IX_Function_1").IsUnique();

            entity.Property(e => e.FunctionId).HasColumnName("FunctionID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.FunctionName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.HasIndex(e => e.GroupName, "IX_Group_1").IsUnique();

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.GroupName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<GroupFunction>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.FunctionId });

            entity.ToTable("GroupFunction");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.FunctionId).HasColumnName("FunctionID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Function).WithMany(p => p.GroupFunctions)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupFunction_Function");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupFunctions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupFunction_Group");
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.UserId });

            entity.ToTable("GroupUser");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupUser_Group");

            entity.HasOne(d => d.User).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupUser_User");
        });

        modelBuilder.Entity<Paid>(entity =>
        {
            entity.ToTable("Paid");

            entity.Property(e => e.PaidId)
                .ValueGeneratedNever()
                .HasColumnName("PaidID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Booking).WithMany(p => p.Paids)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paid_Booking");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.ToTable("Passenger");

            entity.HasIndex(e => new { e.Email, e.PhoneNo }, "IX_Passenger_1").IsUnique();

            entity.Property(e => e.PassengerId)
                .ValueGeneratedNever()
                .HasColumnName("PassengerID");
            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.Dob).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Genger).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNo).HasMaxLength(10);
            entity.Property(e => e.Token)
                .HasMaxLength(50)
                .HasColumnName("token");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethod");

            entity.HasIndex(e => e.PaymentMethodName, "IX_PaymentMethod_1").IsUnique();

            entity.Property(e => e.PaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentMethodID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.PaymentMethodName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<Refund>(entity =>
        {
            entity.ToTable("Refund");

            entity.Property(e => e.RefundId)
                .ValueGeneratedNever()
                .HasColumnName("RefundID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RefundTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Booking).WithMany(p => p.Refunds)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Refund_Booking");
        });

        modelBuilder.Entity<Railway.API.Models.Route>(entity =>
        {
            entity.ToTable("Route");

            entity.HasIndex(e => e.RouteName, "IX_Route_1").IsUnique();

            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.RouteFare).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RouteName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.DepartureStationNavigation).WithMany(p => p.RouteDepartureStationNavigations)
                .HasForeignKey(d => d.DepartureStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Route_Station");

            entity.HasOne(d => d.DestinationStationNavigation).WithMany(p => p.RouteDestinationStationNavigations)
                .HasForeignKey(d => d.DestinationStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Route_Destination_Station");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.ToTable("Seat");

            entity.HasIndex(e => e.SeatNo, "IX_Seat_1").IsUnique();

            entity.Property(e => e.SeatId)
                .ValueGeneratedNever()
                .HasColumnName("SeatID");
            entity.Property(e => e.CoachId).HasColumnName("CoachID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.SeatNo).HasMaxLength(50);
            entity.Property(e => e.SeatTypeId).HasColumnName("SeatTypeID");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            entity.HasOne(d => d.Coach).WithMany(p => p.Seats)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seat_Coach");

            entity.HasOne(d => d.SeatType).WithMany(p => p.Seats)
                .HasForeignKey(d => d.SeatTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seat_SeatType");
        });

        modelBuilder.Entity<SeatType>(entity =>
        {
            entity.ToTable("SeatType");

            entity.HasIndex(e => e.SeatTypeName, "IX_SeatType_1").IsUnique();

            entity.Property(e => e.SeatTypeId)
                .ValueGeneratedNever()
                .HasColumnName("SeatTypeID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.RaitoFare).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SeatTypeName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.ToTable("Station");

            entity.HasIndex(e => e.StationName, "IX_Station_1").IsUnique();

            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.StationName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId)
                .ValueGeneratedNever()
                .HasColumnName("TicketID");
            entity.Property(e => e.ArriveTime).HasColumnType("datetime");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.Fare).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.TrainId).HasColumnName("TrainID");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.ToTable("Train");

            entity.HasIndex(e => e.TrainName, "IX_Train_1").IsUnique();

            entity.Property(e => e.TrainId).HasColumnName("TrainID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.TrainName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => new { e.Email, e.UserName }, "IX_User_1").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.UpdateBy).HasColumnName("updateBy");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
