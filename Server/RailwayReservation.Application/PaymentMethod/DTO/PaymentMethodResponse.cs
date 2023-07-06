using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.DTO
{
    public class PaymentMethodResponse
    {
        public Guid Id { get; set; }

        public string PaymentMethodName { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? UpdateBy { get; set; }

        public PaymentMethodResponse(Guid id, string paymentMethodName, string? description, Guid? createBy, DateTime createTime, Guid? updateBy, DateTime? updateTime)
        {
            Id = id;
            PaymentMethodName = paymentMethodName;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
            UpdateBy = updateBy;
            UpdateTime = updateTime;
        }

        public PaymentMethodResponse()
        {
        }

        public DateTime? UpdateTime { get; set; }
    }
}