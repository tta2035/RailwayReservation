using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces.Persistences
{
    public interface IGroupUserRepository : IGenericRepository<Domain.GroupUser.GroupUser, Domain.GroupUser.GroupUser>
    {
        
    }
}