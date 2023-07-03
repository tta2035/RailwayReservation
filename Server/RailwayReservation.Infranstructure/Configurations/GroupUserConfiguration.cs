using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.GroupFunction;
using RailwayReservation.Domain.GroupUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain.Group.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Infranstructure.Configurations;

public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
{
    public void Configure(EntityTypeBuilder<GroupUser> builder)
    {
        ConfigureGroupUserTable(builder);
    }

    private static void ConfigureGroupUserTable(EntityTypeBuilder<GroupUser> builder)
    {
        builder.HasKey(nameof(GroupUser.GroupId), nameof(GroupUser.UserId));
        builder.ToTable("GroupUser");

        builder
            .Property(e => e.GroupId)
            .HasColumnName("GroupID");
        builder
            .Property(e => e.UserId)
            .HasColumnName("UserID");
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
            .HasOne(d => d.Group)
            .WithMany(p => p.GroupUsers)
            .HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupUser_Group");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.GroupUsers)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GroupUser_User");
    }
}
