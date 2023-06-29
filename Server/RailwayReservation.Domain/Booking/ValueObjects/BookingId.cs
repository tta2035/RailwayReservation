using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Booking.ValueObjects
{
    public sealed class BookingId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BookingId(Guid value)
        {
            Value = value;
        }

        public static BookingId CreateUnique()
        {
            return new BookingId(Guid.NewGuid());
        }

        public static BookingId Create(Guid value)
        {
            return new BookingId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
