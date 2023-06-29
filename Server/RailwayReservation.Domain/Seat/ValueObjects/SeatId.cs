using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Seat.ValueObjects
{
    public sealed class SeatId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private SeatId(Guid value)
        {
            Value = value;
        }

        public static SeatId CreateUnique()
        {
            return new SeatId(Guid.NewGuid());
        }

        public static SeatId Create(Guid value)
        {
            return new SeatId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
