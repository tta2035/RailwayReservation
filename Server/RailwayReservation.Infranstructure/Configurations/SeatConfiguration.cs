using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Coach.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Route;
using RailwayReservation.Domain.Seat;
using RailwayReservation.Domain.Seat.ValueObjects;
using RailwayReservation.Domain.SeatType.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        ConfigureSeatTable(builder);
    }

    private static void ConfigureSeatTable(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seat");

        builder.HasIndex(e => e.SeatNo, "IX_Seat_1").IsUnique();

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => SeatId.Create(value))
            .HasColumnName("SeatID");

        // builder.Property(e => e.SeatId).ValueGeneratedNever().HasColumnName("SeatID");
        builder
            .Property(e => e.CoachId)
            .HasConversion(id => id.Value, value => CoachId.Create(value))
            .HasColumnName("CoachID");
        builder
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.SeatNo).HasMaxLength(50);
        builder
            .Property(e => e.SeatTypeId)
            .HasConversion(id => id.Value, value => SeatTypeId.Create(value))
            .HasColumnName("SeatTypeID");
        builder
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        // builder
        //     .HasOne(d => d.Coach)
        //     .WithMany(p => p.Seats)
        //     .HasForeignKey(d => d.CoachId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_Seat_Coach");

        // builder
        //     .HasOne(d => d.SeatType)
        //     .WithMany(p => p.Seats)
        //     .HasForeignKey(d => d.SeatTypeId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_Seat_SeatType");
    }
}
