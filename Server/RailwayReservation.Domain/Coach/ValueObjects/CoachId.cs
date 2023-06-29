using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Coach.ValueObjects
{
    public class CoachId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private CoachId(Guid value)
        {
            Value = value;
        }

        public static CoachId CreateUnique()
        {
            return new CoachId(Guid.NewGuid());
        }

        public static CoachId Create(Guid value)
        {
            return new CoachId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
