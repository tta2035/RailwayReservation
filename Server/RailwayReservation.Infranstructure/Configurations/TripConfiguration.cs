using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Route.ValueObjects;
using RailwayReservation.Domain.Train.ValueObjects;
using RailwayReservation.Domain.Trip;
using RailwayReservation.Domain.Trip.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Infranstructure.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            ConfigureTripTable(builder);
        }

        private static void ConfigureTripTable(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trip").HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasConversion(id => id.Value, value => TripId.Create(value))
                .HasColumnName("TripID");
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
            builder
                .Property(e => e.RouteId)
                .HasConversion(id => id.Value, value => RouteId.Create(value))
                .HasColumnName("RouteID");
            builder
                .Property(e => e.TrainId)
                .HasConversion(id => id.Value, value => TrainId.Create(value))
                .HasColumnName("TrainID");
            builder
                .Property(e => e.UpdateBy)
                .HasConversion(id => id.Value, value => UserId.Create(value))
                .HasColumnName("updateBy");
            builder
                .Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            builder
                .HasOne(d => d.Route)
                .WithMany(p => p.Trips)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip_Route");

            builder
                .HasOne(d => d.Train)
                .WithMany(p => p.Trips)
                .HasForeignKey(d => d.TrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip_Train");
        }
    }
}
