using RailwayReservation.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Domain.BankingPassenger.ValueObjects;

public sealed class BankingPassengerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public BankingPassengerId(Guid value)
    {
        Value = value;
    }

    public static BankingPassengerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static BankingPassengerId Create(Guid id)
    {
        return new(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
