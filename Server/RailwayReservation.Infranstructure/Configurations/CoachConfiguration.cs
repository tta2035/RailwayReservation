using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.BookingTicket;
using RailwayReservation.Domain.Coach;
using RailwayReservation.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        ConfigureCoachTable(builder);
    }

    private static void ConfigureCoachTable(EntityTypeBuilder<Coach> builder)
    {
        builder.ToTable("Coach");

        builder.HasIndex(e => e.CoachNo, "IX_Coach").IsUnique();

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("CoachID");

        // builder.Property(e => e.CoachId).HasColumnName("CoachID");
        builder.Property(e => e.CoachNo).HasMaxLength(50);
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder
            .Property(e => e.TrainId)
            .HasColumnName("TrainID");
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        builder
            .HasOne(d => d.Train)
            .WithMany(p => p.Coaches)
            .HasForeignKey(d => d.TrainId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Coach_Train");
    }
}
