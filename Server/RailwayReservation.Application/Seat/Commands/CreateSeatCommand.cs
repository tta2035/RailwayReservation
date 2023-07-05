using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RailwayReservation.Application.Seat.Commands
{
    public class CreateSeatCommand : IRequest<Domain.Seat.Seat>
    {
        public Guid CoachId { get; set; }

        public Guid SeatTypeId { get; set; }

        public string SeatNo { get; set; }

        public string? Description { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public CreateSeatCommand(
            Guid coachId,
            Guid seatTypeId,
            string seatNo,
            string? description,
            Guid? createBy,
            DateTime createTime
        )
        {
            CoachId = coachId;
            SeatTypeId = seatTypeId;
            SeatNo = seatNo;
            Description = description;
            CreateBy = createBy;
            CreateTime = createTime;
        }
    }
}
