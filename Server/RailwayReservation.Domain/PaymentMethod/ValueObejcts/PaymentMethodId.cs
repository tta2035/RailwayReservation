using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Domain.Common.Models;

namespace RailwayReservation.Domain.PaymentMethod
{
    public sealed class PaymentMethodId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private PaymentMethodId(Guid value)
        {
            Value = value;
        }

        public static PaymentMethodId CreateUnique()
        {
            return new PaymentMethodId(Guid.NewGuid());
        }

        public static PaymentMethodId Create(Guid value)
        {
            return new PaymentMethodId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
