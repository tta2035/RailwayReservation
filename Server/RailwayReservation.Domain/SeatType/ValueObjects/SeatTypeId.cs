using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.SeatType.ValueObjects
{
    public sealed class SeatTypeId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private SeatTypeId(Guid value)
        {
            Value = value;
        }

        public static SeatTypeId CreateUnique()
        {
            return new SeatTypeId(Guid.NewGuid());
        }

        public static SeatTypeId Create(Guid value)
        {
            return new SeatTypeId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
