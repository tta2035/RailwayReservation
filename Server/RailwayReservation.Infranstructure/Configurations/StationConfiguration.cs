﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.SeatType;
using RailwayReservation.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class StationConfiguration : IEntityTypeConfiguration<Station>
{
    public void Configure(EntityTypeBuilder<Station> builder)
    {
        ConfigureStationTable(builder);
    }

    private static void ConfigureStationTable(EntityTypeBuilder<Station> builder)
    {
        builder.ToTable("Station");

        builder.HasIndex(e => e.StationName, "IX_Station_1").IsUnique();

        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("StationID");
        builder.HasKey(e => e.Id);

        // builder.Property(e => e.StationId).HasColumnName("StationID");
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.StationName).HasMaxLength(50);
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    }
}
