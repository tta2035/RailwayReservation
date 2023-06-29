using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Refund.ValueObjects
{
    public sealed class RefundId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private RefundId(Guid value)
        {
            Value = value;
        }

        public static RefundId CreateUnique()
        {
            return new RefundId(Guid.NewGuid());
        }

        public static RefundId Create(Guid value)
        {
            return new RefundId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
