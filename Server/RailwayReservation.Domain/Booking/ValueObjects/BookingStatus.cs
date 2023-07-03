using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Domain.Booking.ValueObjects;

public enum BookingStatus
{
    Booking,
    PendingPayment,
    Paid,
    Cancelled,
    WaitingRefund,
    Refunded,
    Printed
}
