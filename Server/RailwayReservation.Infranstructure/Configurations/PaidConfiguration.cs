using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.GroupUser;
using RailwayReservation.Domain.Paid;
using RailwayReservation.Domain.Paid.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class PaidConfiguration : IEntityTypeConfiguration<Paid>
{
    public void Configure(EntityTypeBuilder<Paid> builder)
    {
        ConfigurePaidTable(builder);
    }

    private static void ConfigurePaidTable(EntityTypeBuilder<Paid> builder)
    {
        builder.ToTable("Paid");

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => PaidId.Create(value))
            .HasColumnName("PaidID");

        // builder.Property(e => e.PaidId).ValueGeneratedNever().HasColumnName("PaidID");

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
        builder.Property(e => e.PaidAmount).HasColumnType("decimal(18, 0)");
        builder
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // builder
        //     .HasOne(d => d.Booking)
        //     .WithMany(p => p.Paids)
        //     .HasForeignKey(d => d.BookingId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_Paid_Booking");
    }
}
