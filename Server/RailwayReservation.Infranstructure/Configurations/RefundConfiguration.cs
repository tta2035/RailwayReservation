using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.Refund;
using RailwayReservation.Domain.Refund.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class RefundConfiguration : IEntityTypeConfiguration<Refund>
{
    public void Configure(EntityTypeBuilder<Refund> builder)
    {
        ConfigureRefundTable(builder);
    }

    private static void ConfigureRefundTable(EntityTypeBuilder<Refund> builder)
    {
        builder.ToTable("Refund");

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => RefundId.Create(value))
            .HasColumnName("RefundID");

        // builder.Property(e => e.RefundId).ValueGeneratedNever().HasColumnName("RefundID");
        builder
            .Property(e => e.BookingId)
            .HasConversion(id => id.Value, value => BookingId.Create(value))
            .HasColumnName("BookingID");
        builder
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.RefundAmount).HasColumnType("decimal(18, 0)");
        builder
            .Property(e => e.RefundTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // builder
        //     .HasOne(d => d.Booking)
        //     .WithMany(p => p.Refunds)
        //     .HasForeignKey(d => d.BookingId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_Refund_Booking");
    }
}
