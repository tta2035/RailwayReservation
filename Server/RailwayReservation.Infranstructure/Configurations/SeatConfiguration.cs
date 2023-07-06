using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Route;
using RailwayReservation.Domain.Seat;
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
            .HasDefaultValueSql("(newid())")
            .HasColumnName("SeatID");

        // builder.Property(e => e.SeatId).HasDefaultValueSql("(newid())").HasColumnName("SeatID");
        builder
            .Property(e => e.CoachId)
            .HasColumnName("CoachID");
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.SeatNo).HasMaxLength(50);
        builder
            .Property(e => e.SeatTypeId)
            .HasColumnName("SeatTypeID");
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        builder
            .HasOne(d => d.Coach)
            .WithMany(p => p.Seats)
            .HasForeignKey(d => d.CoachId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Seat_Coach");

        builder
            .HasOne(d => d.SeatType)
            .WithMany(p => p.Seats)
            .HasForeignKey(d => d.SeatTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Seat_SeatType");
    }
}
