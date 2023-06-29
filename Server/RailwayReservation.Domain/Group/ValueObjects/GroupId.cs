using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.Group.ValueObjects
{
    public sealed class GroupId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GroupId(Guid value)
        {
            Value = value;
        }

        public static GroupId CreateUnique()
        {
            return new GroupId(Guid.NewGuid());
        }

        public static GroupId Create(Guid value)
        {
            return new GroupId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
