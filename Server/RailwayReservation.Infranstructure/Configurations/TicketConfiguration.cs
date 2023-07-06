using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Station;
using RailwayReservation.Domain.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        ConfigureTicketTable(builder);
    }

    private static void ConfigureTicketTable(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Ticket");

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("TicketID");
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        // builder.Property(e => e.DepartureTime).HasColumnType("datetime");
        // builder.Property(e => e.Fare).HasColumnType("decimal(18, 0)");
        builder
            .Property(e => e.TripId)
            .HasColumnName("TripID");

        builder
            .HasOne(d => d.Trip)
            .WithMany(p => p.Tickets)
            .HasForeignKey(d => d.TripId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Ticket_Trip");

        builder
            .Property(e => e.SeatId)
            .HasColumnName("SeatID");
        builder
            .HasOne(d => d.Seat)
            .WithMany(p => p.Tickets)
            .HasForeignKey(d => d.SeatId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Ticket_Seat");

        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    }
}
