﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

internal class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        ConfigureGroupTable(builder);
    }

    private static void ConfigureGroupTable(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Group");

        builder.HasIndex(e => e.GroupName, "IX_Group_1").IsUnique();

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("GroupID");
        // builder.Property(e => e.GroupId).HasColumnName("GroupID");
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.GroupName).HasMaxLength(50);
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    }
}
