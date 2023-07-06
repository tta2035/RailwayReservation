using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Ticket;
using RailwayReservation.Domain.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class TrainConfiguration : IEntityTypeConfiguration<Train>
{
    public void Configure(EntityTypeBuilder<Train> builder)
    {
        ConfigureTrainTable(builder);
    }

    private static void ConfigureTrainTable(EntityTypeBuilder<Train> builder)
    {
        builder.ToTable("Train");

        builder.HasIndex(e => e.TrainName, "IX_Train_1").IsUnique();

        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("TrainID");

        // builder.Property(e => e.TrainId).HasColumnName("TrainID");
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.TrainName).HasMaxLength(50);
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    }
}
