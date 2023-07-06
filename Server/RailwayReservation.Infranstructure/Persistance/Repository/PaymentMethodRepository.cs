using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.PaymentMethod.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class PaymentMethodRepository
        : GenericRepository<Domain.PaymentMethod.PaymentMethod, PaymentMethodResponse>,
            IPaymentMethodRepository
    {
        public PaymentMethodRepository(RailwayReservationDbContext context) : base(context)
        {
        }

        public override async Task<List<PaymentMethodResponse>> GetAll()
        {
            var result = await (from pm in table
                                select new PaymentMethodResponse()
                                {
                                    Id = pm.Id,
                                    PaymentMethodName = pm.PaymentMethodName,
                                    Description = pm.Description,
                                    CreateBy = pm.CreateBy,
                                    CreateTime = pm.CreateTime,
                                    UpdateBy = pm.UpdateBy,
                                    UpdateTime = pm.UpdateTime,
                                }).ToListAsync();
            return result;
        }

        public override async Task<PaymentMethodResponse?> GetResponseById(Guid id)
        {
            var list = await GetAll();
            return list.Where(e => e.Id == id).Single();
        }
    }
}
