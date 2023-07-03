using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwayReservation.Domain.Booking;
using RailwayReservation.Domain.Booking.ValueObjects;
using RailwayReservation.Domain.BookingTicket;
using RailwayReservation.Domain.BookingTicket.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Ticket.ValueObjects;
using RailwayReservation.Domain.User.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Infranstructure.Configurations;

public class BookingTicketConfiguration : IEntityTypeConfiguration<BookingTicket>
{
    public void Configure(EntityTypeBuilder<BookingTicket> builder)
    {
        ConfigureBookingTicketTable(builder);
    }

    private static void ConfigureBookingTicketTable(EntityTypeBuilder<BookingTicket> builder)
    {
        builder.ToTable("BookingTicket");

        builder.HasKey(nameof(BookingTicket.BookingId), nameof(BookingTicket.TicketId));
        // builder
        //     .Property(e => e.BookingTicketId)
        //     .HasDefaultValueSql("(newid())")
        //     .HasColumnName("BookingTicketID");

        builder
            .Property(e => e.BookingId)
            .HasColumnName("BookingID");

        builder
            .Property(e => e.TicketId)
            .HasColumnName("TicketID");
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
            .HasOne(d => d.Booking)
            .WithMany(p => p.BookingTickets)
            .HasForeignKey(d => d.BookingId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookingTicket_Booking");

        builder
            .HasOne(d => d.Ticket)
            .WithMany(p => p.BookingTickets)
            .HasForeignKey(d => d.TicketId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookingTicket_Ticket");
    }
}
