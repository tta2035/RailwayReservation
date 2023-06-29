using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Station.ValueObjects
{
    public sealed class StationId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        // private StationId(Guid value)
        //     : base(value) { }

        private StationId(Guid value)
        {
            Value = value;
        }

        public static StationId CreateUnique()
        {
            return new StationId(Guid.NewGuid());
        }

        public static StationId Create(Guid value)
        {
            return new StationId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
