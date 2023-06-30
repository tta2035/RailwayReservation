using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.BookingStatus;
using RailwayReservation.Domain.BookingStatus.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Infranstructure.Configurations
{
    public class BookingStatusConfiguration : IEntityTypeConfiguration<BookingStatus>
    {
        public void Configure(EntityTypeBuilder<BookingStatus> builder)
        {
            ConfigureBookingStatusTable(builder);
        }

        private static void ConfigureBookingStatusTable(EntityTypeBuilder<BookingStatus> builder)
        {
            builder.ToTable("BookingStatus");

            builder
                .Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => BookingStatusId.Create(value))
                .HasColumnName("BookingStatusID");
            builder
                .Property(e => e.BookingId)
                .HasConversion(id => id.Value, value => BookingId.Create(value))
                .HasColumnName("BookingID");
            builder
                .Property(e => e.CreateBy)
                .HasConversion(id => id.Value, value => UserId.Create(value))
                .HasColumnName("createBy");
            builder
                .Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            builder.Property(e => e.Status).IsRequired().HasMaxLength(50).IsFixedLength();
            builder
                .Property(e => e.StatusTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("statusTime");
            builder
                .Property(e => e.UpdateBy)
                .HasConversion(id => id.Value, value => UserId.Create(value))
                .HasColumnName("updateBy");
            builder
                .Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");

            builder
                .HasOne(d => d.Booking)
                .WithMany(p => p.BookingStatuses)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingStatus_Booking");
        }
    }
}
