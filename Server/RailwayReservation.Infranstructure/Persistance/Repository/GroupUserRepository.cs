using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class GroupUserRepository : GenericRepository<Domain.GroupUser.GroupUser, Domain.GroupUser.GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(RailwayReservationDbContext context) : base(context)
        {
        }
    }
}