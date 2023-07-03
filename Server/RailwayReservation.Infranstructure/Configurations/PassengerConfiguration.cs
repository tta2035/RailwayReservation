using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Passenger;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        ConfigurePassengerTable(builder);
    }

    private static void ConfigurePassengerTable(EntityTypeBuilder<Passenger> builder)
    {
        builder.ToTable("Passenger").HasKey(d => d.Id);
        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("PassengerID");

        //builder.Property(e => e.PassengerId)
        //    .HasDefaultValueSql("(newid())")
        //    .HasColumnName("PassengerID");

        builder.HasIndex(e => new { e.Email, e.PhoneNo }, "IX_Passenger_1").IsUnique();

        builder.Property(e => e.Address).HasMaxLength(150);
        builder
            .Property(e => e.CreateBy)
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder.Property(e => e.Dob).HasColumnType("date");
        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.FullName).HasMaxLength(50);
        builder.Property(e => e.Genger).HasMaxLength(50);
        builder.Property(e => e.Image).HasMaxLength(50);
        builder.Property(e => e.Password).HasMaxLength(100);
        builder.Property(e => e.PhoneNo).HasMaxLength(10);
        builder.Property(e => e.Token).HasColumnName("token");
        builder
            .Property(e => e.UpdateBy)
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");
    }
}
