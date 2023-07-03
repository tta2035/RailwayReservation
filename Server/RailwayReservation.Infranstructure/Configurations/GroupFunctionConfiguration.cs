using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Function.ValueObjects;
using RailwayReservation.Domain.Group.ValueObjects;
using RailwayReservation.Domain.GroupFunction;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class GroupFunctionConfiguration : IEntityTypeConfiguration<GroupFunction>
{
    public void Configure(EntityTypeBuilder<GroupFunction> builder)
    {
        ConfigureGroupFunctionTable(builder);
    }

    private static void ConfigureGroupFunctionTable(EntityTypeBuilder<GroupFunction> builder)
    {
        builder.HasKey(nameof(GroupFunction.GroupId), nameof(GroupFunction.FunctionId));
        
        builder.ToTable("GroupFunction");

        builder
            .Property(e => e.GroupId)
            .HasColumnName("GroupID");
        builder
            .Property(e => e.FunctionId)
            .HasColumnName("FunctionID");
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        builder
            .HasOne(d => d.Function)
            .WithMany(p => p.GroupFunctions)
            .HasForeignKey(d => d.FunctionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupFunction_Function");

        builder
            .HasOne(d => d.Group)
            .WithMany(p => p.GroupFunctions)
            .HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupFunction_Group");
    }
}
