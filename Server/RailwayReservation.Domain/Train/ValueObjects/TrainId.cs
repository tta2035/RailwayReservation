using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Train.ValueObjects
{
    public sealed class TrainId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private TrainId(Guid value)
        {
            Value = value;
        }

        public static TrainId CreateUnique()
        {
            return new TrainId(Guid.NewGuid());
        }

        public static TrainId Create(Guid value)
        {
            return new TrainId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
