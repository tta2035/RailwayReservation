using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Function.ValueObjects
{
    public sealed class FunctionId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private FunctionId(Guid value)
        {
            Value = value;
        }

        public static FunctionId CreateUnique()
        {
            return new FunctionId(Guid.NewGuid());
        }

        public static FunctionId Create(Guid value)
        {
            return new FunctionId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
