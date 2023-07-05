using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.DTO
{
    public class UpdatePaymentMethodRequest
    {
        public Guid Id { get; set; }

        public string PaymentMethodName { get; set; }

        public string? Description { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public UpdatePaymentMethodRequest(Guid id, string paymentMethodName, string? description, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            PaymentMethodName = paymentMethodName;
            Description = description;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }
    }
}