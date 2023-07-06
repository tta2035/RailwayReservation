using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.BookingStatus;

namespace RailwayReservation.Infranstructure.Configurations
{
    public class BookingStatusConfiguration : IEntityTypeConfiguration<Domain.BookingStatus.BookingStatus>
    {
        public void Configure(EntityTypeBuilder<Domain.BookingStatus.BookingStatus> builder)
        {
            ConfigureBookingStatusTable(builder);
        }

        private static void ConfigureBookingStatusTable(EntityTypeBuilder<Domain.BookingStatus.BookingStatus> builder)
        {
            builder.ToTable("BookingStatus");

            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("BookingStatusID");
            builder
                .Property(e => e.BookingId)
                .HasColumnName("BookingID");
            builder
                .Property(e => e.CreateBy)
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
