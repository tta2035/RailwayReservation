using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Ticket.ValueObjects
{
    public sealed class TicketId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private TicketId(Guid value)
        {
            Value = value;
        }

        public static TicketId CreateUnique()
        {
            return new TicketId(Guid.NewGuid());
        }

        public static TicketId Create(Guid value)
        {
            return new TicketId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
