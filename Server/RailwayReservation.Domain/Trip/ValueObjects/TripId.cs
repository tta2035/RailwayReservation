using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Trip.ValueObjects
{
    public class TripId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private TripId(Guid value)
        {
            Value = value;
        }

        public static TripId CreateUnique()
        {
            return new TripId(Guid.NewGuid());
        }

        public static TripId Create(Guid value)
        {
            return new TripId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}