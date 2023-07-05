using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.PaymentMethod.Commands
{
    public class CreatePaymentMethodCommand : IRequest<Domain.PaymentMethod.PaymentMethod>
    {

        public string PaymentMethodName { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public CreatePaymentMethodCommand(string paymentMethodName, string? description, Guid? createBy, DateTime createTime)
        {
            PaymentMethodName = paymentMethodName;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}