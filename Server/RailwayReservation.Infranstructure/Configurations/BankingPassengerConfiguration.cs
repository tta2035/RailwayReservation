using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.BankingPassenger;
using RailwayReservation.Domain.BankingPassenger.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class BankingPassengerConfiguration : IEntityTypeConfiguration<BankingPassenger>
{
    public void Configure(EntityTypeBuilder<BankingPassenger> builder)
    {
        ConfigureBankingPassengerTable(builder);
    }

    private static void ConfigureBankingPassengerTable(EntityTypeBuilder<BankingPassenger> builder)
    {
        builder.ToTable("BankingPassenger").HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => BankingPassengerId.Create(value))
            .HasColumnName("BankingPassengerID");

        builder.HasIndex(e => e.BankAccountNumber, "IX_BankingPassenger_1").IsUnique();
        
        builder.Property(e => e.BankAccountNumber).HasMaxLength(50);
        builder.Property(e => e.BankName).HasMaxLength(50);
        builder
            .Property(e => e.CreateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("createBy");
        builder
            .Property(e => e.CreateTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("createTime");
        builder
            .Property(e => e.PassengerId)
            .HasConversion(id => id.Value, value => PassengerId.Create(value))
            .HasColumnName("PassengerID");
        builder
            .Property(e => e.PaymentMethodId)
            .HasConversion(id => id.Value, value => PaymentMethodId.Create(value))
            .HasColumnName("PaymentMethodID");
        builder
            .Property(e => e.UpdateBy)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("updateBy");
        builder.Property(e => e.UpdateTime).HasColumnType("datetime").HasColumnName("updateTime");

        builder
            .HasOne(d => d.Passenger)
            .WithMany(p => p.BankingPassengers)
            .HasForeignKey(d => d.PassengerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BankingPassenger_Passenger");

        builder
            .HasOne(d => d.PaymentMethod)
            .WithMany(p => p.BankingPassengers)
            .HasForeignKey(d => d.PaymentMethodId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BankingPassenger_PaymentMethod1");
    }
}
