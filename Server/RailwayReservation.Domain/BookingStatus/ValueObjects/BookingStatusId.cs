using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.BookingStatus.ValueObjects
{
    public class BookingStatusId: AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BookingStatusId(Guid value)
        {
            Value = value;
        }

        public static BookingStatusId CreateUnique()
        {
            return new BookingStatusId(Guid.NewGuid());
        }

        public static BookingStatusId Create(Guid value)
        {
            return new BookingStatusId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}