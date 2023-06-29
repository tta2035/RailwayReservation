using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Route.ValueObjects
{
    public sealed class RouteId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private RouteId(Guid value)
        {
            Value = value;
        }

        public static RouteId CreateUnique()
        {
            return new RouteId(Guid.NewGuid());
        }

        public static RouteId Create(Guid value)
        {
            return new RouteId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
