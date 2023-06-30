﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Seat.ValueObjects;
using RailwayReservation.Domain.Station;
using RailwayReservation.Domain.Ticket;
using RailwayReservation.Domain.Ticket.ValueObjects;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;
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
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => TicketId.Create(value))
            .HasColumnName("TicketID");

        // builder.Property(e => e.TicketId).ValueGeneratedNever().HasColumnName("TicketID");
        builder.Property(e => e.ArriveTime).HasColumnType("datetime");
        builder
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.DepartureTime).HasColumnType("datetime");
        builder.Property(e => e.Fare).HasColumnType("decimal(18, 0)");
        builder
            .Property(e => e.RouteId)
            .HasConversion(id => id.Value, value => RouteId.Create(value))
            .HasColumnName("RouteID");
        builder
            .HasOne(d => d.Route)
            .WithMany(p => p.Tickets)
            .HasForeignKey(d => d.RouteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Ticket_Route");

        builder
            .Property(e => e.SeatId)
            .HasConversion(id => id.Value, value => SeatId.Create(value))
            .HasColumnName("SeatID");
        builder
            .HasOne(d => d.Seat)
            .WithMany(p => p.Tickets)
            .HasForeignKey(d => d.SeatId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Ticket_Seat");

        builder
            .Property(e => e.TrainId)
            .HasConversion(id => id.Value, value => TrainId.Create(value))
            .HasColumnName("TrainID");
        builder
            .HasOne(d => d.Train)
            .WithMany(p => p.Tickets)
            .HasForeignKey(d => d.TrainId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Ticket_Train");

        builder
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    }
}
