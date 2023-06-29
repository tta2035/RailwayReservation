using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Domain;
using RailwayReservation.Domain.BankingPassenger.ValueObjects;
using RailwayReservation.Domain.Common.Models;
using RailwayReservation.Domain.Passenger.ValueObejcts;
using RailwayReservation.Domain.PaymentMethod;
using RailwayReservation.Domain.User.ValueObejcts;

namespace RailwayReservation.Domain.BankingPassenger;

public class BankingPassenger : AggregateRoot<BankingPassengerId, Guid>
{
    // public BankingPassengerId BankingPassengerId { get; set; }

    public PaymentMethodId PaymentMethodId { get; set; }

    public PassengerId PassengerId { get; set; }

    public string BankName { get; set; } = null!;

    public string BankAccountNumber { get; set; } = null!;

    public string? Description { get; set; }

    public UserId? CreateBy { get; set; }

    public DateTime CreateTime { get; set; }

    public UserId? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<Booking.Booking> Bookings { get; set; } = new List<Booking.Booking>();

    public virtual Passenger.Passenger Passenger { get; set; } = null!;

    public virtual PaymentMethod.PaymentMethod PaymentMethod { get; set; } = null!;

    private BankingPassenger() {}

    private BankingPassenger(
        BankingPassengerId bankingPassengerId,
        PaymentMethodId paymentMethodId,
        PassengerId passengerId,
        string bankName,
        string bankAccountNumber,
        string? description,
        UserId createBy,
        DateTime createTime,
        UserId? updateBy,
        DateTime? updateTime
    )
        : base(bankingPassengerId)
    {
        // BankingPassengerId = bankingPassengerId;
        PaymentMethodId = paymentMethodId;
        PassengerId = passengerId;
        BankName = bankName;
        BankAccountNumber = bankAccountNumber;
        Description = description;
        CreateBy = createBy;
        CreateTime = createTime;
        UpdateBy = updateBy;
        UpdateTime = updateTime;
    }

    private static BankingPassenger Create(
        PaymentMethodId paymentMethodId,
        PassengerId passengerId,
        string bankName,
        string bankAccountNumber,
        string? description
    )
    {
        return new(
            BankingPassengerId.CreateUnique(),
            paymentMethodId,
            passengerId,
            bankName,
            bankAccountNumber,
            description,
            null,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow
        );
    }
}
