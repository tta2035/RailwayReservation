using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.BookingTicket.ValueObjects
{
    public class BookingTicketId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BookingTicketId(Guid value)
        {
            Value = value;
        }

        public static BookingTicketId CreateUnique()
        {
            return new BookingTicketId(Guid.NewGuid());
        }

        public static BookingTicketId Create(Guid value)
        {
            return new BookingTicketId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
