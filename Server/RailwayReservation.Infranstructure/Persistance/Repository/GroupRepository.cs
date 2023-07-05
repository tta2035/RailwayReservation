using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using RailwayReservation.Application.Group.DTO;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class GroupRepository
        : GenericRepository<Domain.Group.Group, GroupResponse>,
            IGroupRepository
    {
        public GroupRepository(RailwayReservationDbContext context)
            : base(context) { }
    }
}
