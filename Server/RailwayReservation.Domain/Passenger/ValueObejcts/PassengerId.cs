using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Passenger.ValueObejcts
{
    public sealed class PassengerId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private PassengerId(Guid value) {
            Value = value;
        }

        public static PassengerId CreateUnique() {
            return new PassengerId(Guid.NewGuid());
        }

        public static PassengerId Create(Guid value) {
            return new PassengerId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Guid(PassengerId passengerId) => passengerId.Value;
    }
}