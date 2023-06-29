using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Paid.ValueObjects
{
    public sealed class PaidId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private PaidId(Guid value)
        {
            Value = value;
        }

        public static PaidId CreateUnique()
        {
            return new PaidId(Guid.NewGuid());
        }

        public static PaidId Create(Guid value)
        {
            return new PaidId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
