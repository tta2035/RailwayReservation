using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Booking;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        ConfigureBookingTable(builder);
    }

    private static void ConfigureBookingTable(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking").HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => BookingId.Create(value))
            .HasColumnName("BookingID");

        // builder.Property(e => e.BookingId).ValueGeneratedNever().HasColumnName("BookingID");
        builder.Property(e => e.CancellationFee).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.CancellationTime).HasColumnType("datetime");
        builder
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");

        builder.Property(e => e.PaymentTerm).HasColumnType("datetime");
        builder.Property(e => e.TotalFare).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.TotalPayment).HasColumnType("decimal(18, 0)");
        builder
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        builder
            .Property(e => e.PassengerId)
            .HasConversion(id => id.Value, value => PassengerId.Create(value))
            .HasColumnName("PassengerId");
        builder
            .HasOne(d => d.Passenger)
            .WithMany(p => p.Bookings)
            .HasForeignKey(d => d.PassengerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Booking_Passenger");

        builder
            .Property(e => e.PaymentMethodId)
            .HasConversion(id => id.Value, value => PaymentMethodId.Create(value))
            .HasColumnName("PaymentMethodID");

        builder
            .HasOne(d => d.PaymentMethod)
            .WithMany(p => p.Bookings)
            .HasForeignKey(d => d.PaymentMethodId)
            .HasConstraintName("FK_Booking_PaymentMethod");
    }
}
