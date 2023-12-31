﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Seat;
using RailwayReservation.Domain.SeatType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
{
    public void Configure(EntityTypeBuilder<SeatType> builder)
    {
        ConfigureSeatTypeTable(builder);
    }

    private static void ConfigureSeatTypeTable(EntityTypeBuilder<SeatType> builder)
    {
        builder.ToTable("SeatType");

        builder.HasIndex(e => e.SeatTypeName, "IX_SeatType_1").IsUnique();

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("SeatTypeID");
        // builder.Property(e => e.SeatTypeId).HasDefaultValueSql("(newid())").HasColumnName("SeatTypeID");
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        // builder.Property(e => e.RaitoFare).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.SeatTypeName).HasMaxLength(50);
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    }
}
